using System.IO;

namespace YoutubeDownloader
{
    public class DownloadFileInfo
    {
        public DownloadFileInfo(string url)
        {
            Url = url;
            if (url.Contains("youtu.be"))
            {
                var ind1 = url.IndexOf("youtu.be/");
                Hash = url.Substring(ind1 + "youtu.be/".Length);                
            }
            else if (url.Contains("v="))
            {
                var ind1 = url.IndexOf("v=");
                Hash = url.Substring(ind1 + 2);
            }
        }

        public bool IsDownloaded => !string.IsNullOrEmpty(FilePath) && File.Exists(Path.Combine("Downloads", FilePath));
        public string Url { get; private set; }
        public string Hash { get; private set; }
        public string FilePath;
        public DownloadStateEnum State;

        internal static DownloadFileInfo Create(string value)
        {
            return new DownloadFileInfo(value);
        }
    }
    public enum DownloadStateEnum
    {
        NotStarted, Downloaded, Timeout
    }
}
