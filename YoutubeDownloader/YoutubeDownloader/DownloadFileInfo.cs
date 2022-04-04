using System.IO;

namespace YoutubeDownloader
{
    public class DownloadFileInfo
    {
        public DownloadFileInfo(string url)
        {
            Url = url;
            var ind1 = url.IndexOf("v=");
            Hash = url.Substring(ind1 + 1);
        }
        public bool IsDownloaded => !string.IsNullOrEmpty(FilePath) && File.Exists(Path.Combine("Downloads", FilePath));
        public string Url { get; private set; }
        public string Hash { get; private set; }
        public string FilePath;

        internal static DownloadFileInfo Create(string value)
        {
            return new DownloadFileInfo(value);
        }
    }
}
