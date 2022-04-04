using System.Windows.Forms;

namespace YoutubeDownloader
{
    public static class Stuff
    {
        public static DialogResult Warning(string v, Form f)
        {
            return MessageBox.Show(v, f.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
