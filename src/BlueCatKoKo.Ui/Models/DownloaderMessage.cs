using BlueCatKoKo.Ui.Constants;

namespace BlueCatKoKo.Ui.Models
{
    /// <summary>
    ///     下载器消息
    /// </summary>
    /// <param name="Type"></param>
    /// <param name="Message"></param>
    /// <param name="Url"></param>
    public record DownloaderMessage(
        DownloaderEnum Type,
        // 消息文本
        string Message,
        // 链接
        string Url
    );
}