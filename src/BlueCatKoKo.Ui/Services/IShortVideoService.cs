using System.ComponentModel;

using BlueCatKoKo.Ui.Models;

using Downloader;

namespace BlueCatKoKo.Ui.Services
{
    public interface IShortVideoService
    {
        Task<string> ExtractUrlAsync(string text);

        Task<VideoModel> ExtractVideoDataAsync(string url);

        Task DownloadAsync(string url, string savePath, string fileName,
            EventHandler<DownloadProgressChangedEventArgs> onProgressChanged,
            EventHandler<AsyncCompletedEventArgs> onProgressCompleted);
    }
}