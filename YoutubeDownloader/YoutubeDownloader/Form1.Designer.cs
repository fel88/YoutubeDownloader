namespace YoutubeDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button4 = new System.Windows.Forms.Button();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            button3 = new System.Windows.Forms.Button();
            listView1 = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            browserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            locateInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            extractAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            removeAllDownloadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            downloadListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            downloadSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            button2 = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            button6 = new System.Windows.Forms.Button();
            checkBox3 = new System.Windows.Forms.CheckBox();
            checkBox2 = new System.Windows.Forms.CheckBox();
            button5 = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            checkBox1 = new System.Windows.Forms.CheckBox();
            contextMenuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button4.Image = Properties.Resources.drive_download;
            button4.Location = new System.Drawing.Point(709, 46);
            button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(103, 27);
            button4.TabIndex = 19;
            button4.Text = "Downloads";
            button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            progressBar1.Location = new System.Drawing.Point(4, 321);
            progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(824, 29);
            progressBar1.TabIndex = 18;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            richTextBox1.Location = new System.Drawing.Point(4, 356);
            richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(824, 109);
            richTextBox1.TabIndex = 17;
            richTextBox1.Text = "";
            // 
            // textBox2
            // 
            textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox2.Location = new System.Drawing.Point(97, 46);
            textBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(597, 23);
            textBox2.TabIndex = 16;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.plus;
            button3.Location = new System.Drawing.Point(2, 44);
            button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(88, 27);
            button3.TabIndex = 15;
            button3.Text = "Add URL";
            button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new System.Drawing.Point(4, 118);
            listView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(824, 197);
            listView1.TabIndex = 13;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "URL";
            columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Target";
            columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Progress";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripMenuItem, locateInExplorerToolStripMenuItem, clearToolStripMenuItem, deleteToolStripMenuItem, copyToolStripMenuItem, pasteURLToolStripMenuItem, extractAudioToolStripMenuItem, removeAllDownloadedToolStripMenuItem, toolStripSeparator1, downloadListToolStripMenuItem, downloadSelectedToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(199, 230);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, browserToolStripMenuItem });
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            openToolStripMenuItem.Text = "open";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            fileToolStripMenuItem.Text = "file";
            fileToolStripMenuItem.Click += fileToolStripMenuItem_Click;
            // 
            // browserToolStripMenuItem
            // 
            browserToolStripMenuItem.Name = "browserToolStripMenuItem";
            browserToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            browserToolStripMenuItem.Text = "browser";
            browserToolStripMenuItem.Click += browserToolStripMenuItem_Click;
            // 
            // locateInExplorerToolStripMenuItem
            // 
            locateInExplorerToolStripMenuItem.Image = Properties.Resources.folder_horizontal_open;
            locateInExplorerToolStripMenuItem.Name = "locateInExplorerToolStripMenuItem";
            locateInExplorerToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            locateInExplorerToolStripMenuItem.Text = "locate in explorer";
            locateInExplorerToolStripMenuItem.Click += locateInExplorerToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Image = Properties.Resources.broom;
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            clearToolStripMenuItem.Text = "clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = Properties.Resources.cross;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            deleteToolStripMenuItem.Text = "delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = Properties.Resources.document_copy;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            copyToolStripMenuItem.Text = "copy URL";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteURLToolStripMenuItem
            // 
            pasteURLToolStripMenuItem.Image = Properties.Resources.briefcase;
            pasteURLToolStripMenuItem.Name = "pasteURLToolStripMenuItem";
            pasteURLToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            pasteURLToolStripMenuItem.Text = "paste URL";
            pasteURLToolStripMenuItem.Click += pasteURLToolStripMenuItem_Click;
            // 
            // extractAudioToolStripMenuItem
            // 
            extractAudioToolStripMenuItem.Image = Properties.Resources.music__arrow;
            extractAudioToolStripMenuItem.Name = "extractAudioToolStripMenuItem";
            extractAudioToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            extractAudioToolStripMenuItem.Text = "extract audio";
            extractAudioToolStripMenuItem.Click += extractAudioToolStripMenuItem_Click;
            // 
            // removeAllDownloadedToolStripMenuItem
            // 
            removeAllDownloadedToolStripMenuItem.Name = "removeAllDownloadedToolStripMenuItem";
            removeAllDownloadedToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            removeAllDownloadedToolStripMenuItem.Text = "remove all downloaded";
            removeAllDownloadedToolStripMenuItem.Click += removeAllDownloadedToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // downloadListToolStripMenuItem
            // 
            downloadListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exportToolStripMenuItem, importToolStripMenuItem });
            downloadListToolStripMenuItem.Image = Properties.Resources.arrow_skip_270;
            downloadListToolStripMenuItem.Name = "downloadListToolStripMenuItem";
            downloadListToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            downloadListToolStripMenuItem.Text = "download list";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            exportToolStripMenuItem.Text = "export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            importToolStripMenuItem.Text = "import";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // downloadSelectedToolStripMenuItem
            // 
            downloadSelectedToolStripMenuItem.Name = "downloadSelectedToolStripMenuItem";
            downloadSelectedToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            downloadSelectedToolStripMenuItem.Text = "download selected";
            downloadSelectedToolStripMenuItem.Click += downloadSelectedToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(748, 13);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(64, 27);
            button1.TabIndex = 12;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(24, 18);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 15);
            label1.TabIndex = 11;
            label1.Text = "yt-dlp path";
            // 
            // textBox1
            // 
            textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox1.Location = new System.Drawing.Point(97, 15);
            textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(643, 23);
            textBox1.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(button2, 0, 4);
            tableLayoutPanel1.Controls.Add(richTextBox1, 0, 3);
            tableLayoutPanel1.Controls.Add(progressBar1, 0, 2);
            tableLayoutPanel1.Controls.Add(listView1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new System.Drawing.Size(832, 528);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // button2
            // 
            button2.Dock = System.Windows.Forms.DockStyle.Fill;
            button2.Image = Properties.Resources.drive_download;
            button2.Location = new System.Drawing.Point(4, 471);
            button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(824, 54);
            button2.TabIndex = 14;
            button2.Text = "Download all";
            button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button6);
            panel1.Controls.Add(checkBox3);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(button3);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(4, 3);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(824, 109);
            panel1.TabIndex = 19;
            // 
            // button6
            // 
            button6.Image = Properties.Resources.music__arrow;
            button6.Location = new System.Drawing.Point(599, 74);
            button6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(103, 27);
            button6.TabIndex = 27;
            button6.Text = "extract audio";
            button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new System.Drawing.Point(489, 80);
            checkBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(101, 19);
            checkBox3.TabIndex = 26;
            checkBox3.Text = "clean subtitles";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new System.Drawing.Point(438, 80);
            checkBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(39, 19);
            checkBox2.TabIndex = 25;
            checkBox2.Text = "srt";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(710, 73);
            button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(103, 27);
            button5.TabIndex = 24;
            button5.Text = "Settings";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(226, 84);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 15);
            label2.TabIndex = 23;
            label2.Text = "Mode";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Video", "Subtitles" });
            comboBox1.Location = new System.Drawing.Point(273, 77);
            comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(140, 23);
            comboBox1.TabIndex = 22;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new System.Drawing.Point(141, 74);
            numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown1.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(70, 23);
            numericUpDown1.TabIndex = 21;
            numericUpDown1.Value = new decimal(new int[] { 30, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(10, 77);
            checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(117, 19);
            checkBox1.TabIndex = 20;
            checkBox1.Text = "use timeout (sec)";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(832, 528);
            Controls.Add(tableLayoutPanel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(522, 513);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Youtube Downloader";
            contextMenuStrip1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem downloadListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteURLToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem removeAllDownloadedToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ToolStripMenuItem locateInExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractAudioToolStripMenuItem;
        private System.Windows.Forms.Button button6;
    }
}

