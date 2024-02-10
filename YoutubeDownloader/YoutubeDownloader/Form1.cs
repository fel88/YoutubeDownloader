using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace YoutubeDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckSettings();
            LoadSettings();
        }

        private void CheckSettings()
        {
            if (File.Exists("settings.xml")) return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\"?>");
            sb.AppendLine("<settings>");
            sb.AppendLine("</settings>");
            File.WriteAllText("settings.xml", sb.ToString());
        }

        public void LoadSettings()
        {
            if (!File.Exists("settings.xml")) return;

            try
            {
                var doc = XDocument.Load("settings.xml");
                textBox1.Text = doc.Element("settings").Element("extras").Element("ytdlp").Element("exePath").Value;
                ffmpegPath = doc.Element("settings").Element("extras").Element("ffmpeg").Element("exePath").Value;
            }
            catch (Exception ex)
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "exe files|*.exe";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            textBox1.Text = ofd.FileName;

            UpdateSettings();
        }

        public void UpdateSettings()
        {
            //update setting
            if (!File.Exists("settings.xml"))
                return;

            try
            {
                var doc = XDocument.Load("settings.xml");
                var fr = doc.Descendants("settings").First();
                var ext = fr.Element("extras");
                if (ext == null)
                {
                    fr.Add(new XElement("extras"));
                    ext = fr.Element("extras");
                }
                var ffmpeg = ext.Element("ffmpeg");
                if (ffmpeg == null)
                {
                    ext.Add(new XElement("ffmpeg"));
                    ffmpeg = ext.Element("ffmpeg");
                }
                var exep2 = ffmpeg.Element("exePath");
                if (exep2 == null)
                {
                    ffmpeg.Add(new XElement("exePath"));
                    exep2 = ffmpeg.Element("exePath");
                }
                exep2.ReplaceNodes(new XCData(ffmpegPath));

                var ytdlp = ext.Element("ytdlp");
                if (ytdlp == null)
                {
                    ext.Add(new XElement("ytdlp"));
                    ytdlp = ext.Element("ytdlp");
                }

                var exep = ytdlp.Element("exePath");
                if (exep == null)
                {
                    ytdlp.Add(new XElement("exePath"));
                    exep = ytdlp.Element("exePath");
                }
                exep.ReplaceNodes(new XCData(textBox1.Text));

                doc.Save("settings.xml");
            }
            catch (Exception ex)
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                new Uri(textBox2.Text);
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Text == textBox2.Text)
                    {
                        Stuff.Warning($"{textBox2.Text} already was added", this);
                        return;
                    }
                }
                listView1.Items.Add(new ListViewItem(new string[] { textBox2.Text, string.Empty, string.Empty }) { Tag = DownloadFileInfo.Create(textBox2.Text) });
                textBox2.Text = string.Empty;

                textBox2.BackColor = Color.White;
                textBox2.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                textBox2.BackColor = Color.Red;
                textBox2.ForeColor = Color.White;
            }
        }

        Process p;

        void download(string exePath, string args, string preArgs = "")
        {
            Directory.CreateDirectory("Downloads");
            ProcessStartInfo pci = new ProcessStartInfo(exePath)
            {
                Arguments = $"{preArgs} {args}",
                WorkingDirectory = "Downloads",
                CreateNoWindow = true
            };
            p = new Process();
            p.StartInfo = pci;

            //p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(65001);
            //p.StartInfo.StandardErrorEncoding = Encoding.GetEncoding(65001);

            p.EnableRaisingEvents = true;
            p.OutputDataReceived += P_OutputDataReceived;
            p.ErrorDataReceived += P_OutputDataReceived;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.Exited += P_Exited;
            p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(850);


            lastDownloadInfo = null;

            p.Start();

            p.BeginOutputReadLine();

            bool good = true;
            if (useTimeout)
            {
                if (!p.WaitForExit(timeout))
                {
                    PrintText("wait time expired. terminate");

                    var l = GetListItem(args.Trim());
                    UpdateListViewItem(l, (item) =>
                    {
                        (l.Tag as DownloadFileInfo).State = DownloadStateEnum.Timeout;
                        item.BackColor = Color.Red;
                        item.SubItems[2].Text = "timeout";
                    });
                    good = false;

                    p.Kill();
                }
            }
            else
            {
                p.WaitForExit();
            }
            if (good)
            {
                var l = GetListItem(args.Trim());
                UpdateListViewItem(l, (item) =>
                {
                    var dd = l.Tag as DownloadFileInfo;
                    dd.State = DownloadStateEnum.Downloaded;
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DownloadItems(listView1.Items);
        }

        private void DownloadList(string[] list, string path, string preArgs = "")
        {
            Thread th = new Thread(() =>
            {
                foreach (var item in list)
                    download(path, item, preArgs);

                PrintText("well done.");
            });
            th.IsBackground = true;
            th.Start();
        }

        private void P_Exited(object sender, EventArgs e)
        {
            PrintText("terminated");
        }

        ListViewItem GetListItem(string hash)
        {
            ListViewItem ret = null;
            listView1.Invoke((Action)(() =>
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    var d = (listView1.Items[i].Tag as DownloadFileInfo);
                    if (d.Url.Contains(hash))
                    {
                        ret = listView1.Items[i];
                        break;
                    }
                }

            }));
            return ret;
        }

        void UpdateListViewItem(ListViewItem item, Action<ListViewItem> action)
        {
            listView1.Invoke((Action)(() =>
            {
                action(item);
            }));
        }

        DownloadFileInfo lastDownloadInfo = null;
        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;

            if (e.Data.Contains("has already been downloaded"))
            {
                var ind = e.Data.IndexOf(':');
                var name = e.Data.Substring(ind + 1).Replace("[download]", "").Replace("has already been downloaded", "").Trim();              
                var ind2 = e.Data.LastIndexOf('[');
                var ind3 = e.Data.LastIndexOf(']');
                var url = e.Data.Substring(ind2 + 1, ind3 - ind2 - 1);
                var l = GetListItem(url);                 
                
                var dd = l.Tag as DownloadFileInfo;
                try
                {
                    var ff = Path.GetFileName(SearchFileByHash(dd.Hash));
                    name = ff;
                }
                catch (Exception ex)
                {

                }
                UpdateListViewItem(l, (item) =>
                {
                    item.SubItems[1].Text = name;
                    item.SubItems[2].Text = "100%";
                });

                (l.Tag as DownloadFileInfo).FilePath = name;
                lastDownloadInfo = l.Tag as DownloadFileInfo;
            }
            else if (e.Data.Contains("Destination"))
            {

                try
                {
                    var ind = e.Data.IndexOf(':');
                    var name = e.Data.Substring(ind + 1).Trim();
                    var ind2 = e.Data.LastIndexOf('[');
                    var ind3 = e.Data.LastIndexOf(']');
                    var url = e.Data.Substring(ind2 + 1, ind3 - ind2 - 1);
                    var l = GetListItem(url);

                    var dd = l.Tag as DownloadFileInfo;
                    try
                    {
                        var ff = Path.GetFileName(SearchFileByHash(dd.Hash));
                        name = ff;
                    }
                    catch (Exception ex)
                    {

                    }

                    UpdateListViewItem(l, (item) =>
                    {
                        item.SubItems[1].Text = name;
                    });
                    (l.Tag as DownloadFileInfo).FilePath = name;
                    lastDownloadInfo = l.Tag as DownloadFileInfo;
                }
                catch (Exception ex)
                {

                }
            }
            if (e.Data.Contains("%"))
            {
                var arr = e.Data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Contains("%"))
                    {
                        var perc = arr[i].Replace("%", "");
                        try
                        {
                            var val = float.Parse(perc.Replace(",", "."), CultureInfo.InvariantCulture);
                            if (lastDownloadInfo != null)
                            {
                                var l = GetListItem(lastDownloadInfo.Hash);
                                UpdateListViewItem(l, (item) =>
                                {
                                    item.SubItems[2].Text = (int)Math.Round(val) + "%";
                                });
                            }

                            progressBar1.Invoke((Action)(() =>
                            {
                                progressBar1.Value = (int)Math.Round(val);
                            }));
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            PrintText(e.Data + Environment.NewLine);
        }

        public void PrintText(string text)
        {
            richTextBox1.Invoke((Action)(() =>
            {
                richTextBox1.AppendText(text);
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }));

        }

        public bool Question(string text)
        {
            return MessageBox.Show(text, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Question("Are you sure to clear list?")) return;
            listView1.Items.Clear();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            if (!Question($"Are you sure to delete {listView1.SelectedItems.Count} items?")) return;

            List<ListViewItem> toDel = new List<ListViewItem>();
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                toDel.Add(listView1.SelectedItems[i]);
            }
            foreach (var t in toDel)
            {
                listView1.Items.Remove(t);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("Downloads"))
            {
                Directory.CreateDirectory("Downloads");
            }
            Process.Start("Downloads");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            Clipboard.SetText(listView1.SelectedItems[0].Text);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\"?>");
            sb.AppendLine("<root>");
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sb.AppendLine($"<url><![CDATA[{listView1.Items[i].Text}]]></url>");
            }
            sb.AppendLine("</root>");
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "xml|*.xml";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            File.WriteAllText(sfd.FileName, sb.ToString());
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xml|*.xml";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            var doc = XDocument.Load(ofd.FileName);
            listView1.Items.Clear();
            foreach (var item in doc.Descendants("url"))
            {
                listView1.Items.Add(new ListViewItem(new string[] { item.Value, string.Empty, string.Empty }) { Tag = DownloadFileInfo.Create(item.Value) });
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var d = (listView1.SelectedItems[0].Tag as DownloadFileInfo);
            if (!d.IsDownloaded) return;

            Process.Start(Path.Combine("Downloads", d.FilePath));
        }

        private void browserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            Process.Start(listView1.SelectedItems[0].Text);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var d = (listView1.SelectedItems[0].Tag as DownloadFileInfo);
            if (d.State != DownloadStateEnum.Downloaded) return;

            var path = Path.Combine("Downloads", d.FilePath);
            if (!File.Exists(path))
            {
                var dir = new DirectoryInfo("Downloads");

                foreach (var item in dir.GetFiles())
                {
                    if (item.Name.Contains($"[{d.Hash}]"))
                    {
                        Process.Start(item.FullName);
                        break;
                    }
                }
            }
            else
                Process.Start(path);
        }
        public void DownloadItems(IEnumerable items)
        {
            if (!File.Exists(textBox1.Text))
            {
                Stuff.Warning($"File {textBox1.Text} doesn't exist", this);
                return;
            }
            List<string> list = new List<string>();
            foreach (var item in items)
            {
                list.Add((item as ListViewItem).Text);
            }
            var path = textBox1.Text;
            //--ffmpeg-location C:\Users\fel\Downloads\ffmpeg-master-latest-win64-gpl-shared\ffmpeg-master-latest-win64-gpl-shared\bin 
            string preArgs = string.Empty;

            if (mode == 1)
            {
                preArgs = @"--sub-lang ru --skip-download --write-auto-sub ";
            }
            if (srt)
            {
                if (string.IsNullOrEmpty(ffmpegPath) || !Directory.Exists(ffmpegPath))
                    MessageBox.Show("SRT not available. Fix ffmpeg path", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    preArgs += $"--convert-subs=srt  --ffmpeg-location {ffmpegPath}";
            }

            DownloadList(list.ToArray(), path, preArgs);
        }

        private void downloadSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadItems(listView1.SelectedItems);
        }

        private void pasteURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var txts = Clipboard.GetText().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (var _txt in txts)
                {
                    var txt = _txt.Trim();
                    new Uri(txt);
                    bool exit = false;
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].Text == txt)
                        {
                            Stuff.Warning($"{txt} already was added", this);
                            exit = true;
                            break;
                        }
                    }
                    if (exit)
                        continue;

                    listView1.Items.Add(new ListViewItem(new string[] { txt, string.Empty, string.Empty }) { Tag = DownloadFileInfo.Create(txt) });
                }
            }
            catch (Exception ex)
            {

            }
        }
        bool useTimeout = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            useTimeout = checkBox1.Checked;
        }
        int timeout = 30 * 1000;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timeout = (int)numericUpDown1.Value * 1000;
        }

        private void removeAllDownloadedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ListViewItem> toDel = new List<ListViewItem>();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if ((listView1.Items[i].Tag as DownloadFileInfo).State != DownloadStateEnum.Downloaded)
                    continue;

                toDel.Add(listView1.Items[i]);
            }
            foreach (var t in toDel)
            {
                listView1.Items.Remove(t);
            }
        }

        int mode = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = comboBox1.SelectedIndex;
        }

        string ffmpegPath = "";
        private void button5_Click(object sender, EventArgs e)
        {
            var d = AutoDialog.DialogHelpers.StartDialog();
            d.AddStringField("ffmpeg", "FFmpeg path", ffmpegPath);
            if (!d.ShowDialog())
                return;

            ffmpegPath = d.GetStringField("ffmpeg");
            UpdateSettings();
        }

        bool srt = false;
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            srt = checkBox2.Checked;
        }

        bool cleanSubtitles = false;
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            cleanSubtitles = checkBox3.Checked;

        }

        public string SearchFileByHash(string hash)
        {
            var dir = new DirectoryInfo("Downloads");

            foreach (var item in dir.GetFiles())
            {
                if (item.Name.Contains($"[{hash}]"))
                {
                    return item.FullName;
                }
            }
            return null;
        }

        private void locateInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            var d = (listView1.SelectedItems[0].Tag as DownloadFileInfo);
            if (!d.IsDownloaded)
                return;

            var file = SearchFileByHash(d.Hash);

            string args = string.Format("/e, /select, \"{0}\"", file);

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.Arguments = args;
            Process.Start(info);
        }
    }
}
