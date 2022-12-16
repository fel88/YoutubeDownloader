using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ffmpegGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadConfig();
            FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        public void SaveConfig()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\"?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<setting name=\"ffmpegPath\">");
            var d = new XCData(textBox2.Text);
            var str = d.ToString();
            sb.AppendLine(str);
            sb.AppendLine("</setting>");
            sb.AppendLine("</root>");

            File.WriteAllText("config.xml", sb.ToString());
        }

        private void LoadConfig()
        {
            if (!File.Exists("config.xml"))
            {
                return;
            }
            var doc = XDocument.Load("config.xml");
            foreach (var item in doc.Descendants("setting"))
            {
                var nm = item.Attribute("name").Value;
                switch (nm)
                {
                    case "ffmpegPath":
                        textBox2.Text = item.Value;
                        break;
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox2.Text))
            {
                MessageBox.Show($"File {textBox2.Text} not found", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show($"File {textBox1.Text} not found", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists("out1.aac"))
            {
                File.Delete("out1.aac");
            }
            var b64 = Convert.ToBase64String(Encoding.Default.GetBytes(textBox1.Text));
            ProcessStartInfo psi = null;
            if (trimEnabled)
            {
                psi = new ProcessStartInfo("bat2.bat");
                psi.Arguments = $"\"{b64}\" \"{textBox2.Text}\" {startTime} {endTime} out1.aac";
            }
            else
            {
                psi = new ProcessStartInfo("bat.bat"); 
                psi.Arguments = $"\"{b64}\" \"{textBox2.Text}\" out1.aac";                
            }

          
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;

            var target = Path.GetFileNameWithoutExtension(new FileInfo(textBox1.Text).Name) + ".aac";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = target;
            if (sfd.ShowDialog() != DialogResult.OK) return;
            target = sfd.FileName;

            await Task.Run(() =>
            {
                var p = Process.Start(psi);
                p.WaitForExit();

                if (File.Exists(target))
                {
                    if (MessageBox.Show("Rewrite +" + target + "?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(target);
                    }
                    else return;
                }
                File.Move("out1.aac", target);

            });
            toolStripStatusLabel1.Text = target + " saved!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            textBox1.Text = ofd.FileName;
        }

        bool trimEnabled = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            trimEnabled = checkBox1.Checked;
        }

        TimeSpan startTime = new TimeSpan();
        TimeSpan endTime = new TimeSpan();
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                startTime = TimeSpan.Parse(textBox3.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                endTime = TimeSpan.Parse(textBox4.Text);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
