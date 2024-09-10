using System.ComponentModel;

using BlueCatKoKo.Ui.Models.Pages;

using Downloader;

namespace BlueCatKoKo.Ui.Services
{
    public interface IDownloaderService
    {
        public Task<string> ExtractUrlAsync(string text);

        public Task<VideoModel> ExtractVideoDataAsync(string url);

        public Task DownloadAsync(string url, string savePath, string fileName,
            EventHandler<DownloadProgressChangedEventArgs> onProgressChanged,
            EventHandler<AsyncCompletedEventArgs> onProgressCompleted);
    }
}