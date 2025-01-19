using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using BlueCatKoKo.Ui.Constants;
using BlueCatKoKo.Ui.Models;
using Downloader;
using Newtonsoft.Json;
using RestSharp;
using Serilog;

namespace BlueCatKoKo.Ui.Services;

/// <summary>
///     快手下载服务
/// </summary>
public class KuaiShouShortVideoService : IShortVideoService
{
    private static readonly Dictionary<string, string> _locationHeaders = new()
    {
        {
            "Accept",
            "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
        },
        { "Accept-Language", "zh-CN,zh;q=0.9" },
        { "Cache-Control", "no-cache" },
        { "Connection", "keep-alive" },
        { "DNT", "1" },
        { "Host", "www.kuaishou.com" },
        { "Pragma", "no-cache" },
        { "Sec-Fetch-Dest", "document" },
        { "Sec-Fetch-Mode", "navigate" },
        { "Sec-Fetch-Site", "none" },
        { "Sec-Fetch-User", "?1" },
        { "Upgrade-Insecure-Requests", "1" },
        {
            "UserAgent",
            "Mozilla/5.0 (Linux; Android 8.0.0; SM-G955U Build/R16NW) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Mobile Safari/537.36"
        },
        { "sec-ch-ua", "\"Chromium\";v=\"128\", \"Not;A=Brand\";v=\"24\", \"Google Chrome\";v=\"128\"" },
        { "sec-ch-ua-mobile", "?1" },
        { "sec-ch-ua-platform", "\"Android\"" }
        // {
        //     "Cookie",
        //     "kpf=PC_WEB; kpn=KUAISHOU_VISION; clientid=3; did=web_6ece7cfdd334f69ac1fe2579040329d0; didv=1725957114469"
        // }
    };

    private static readonly Dictionary<string, string> _videoInfoHeaders = new()
    {
        { "Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7" },
        { "Accept-Encoding", "gzip, deflate, br, zstd" },
        { "Accept-Language", "zh-CN,zh;q=0.9" },
        { "Cache-Control", "no-cache" },
        { "Connection", "keep-alive" },
        { "Cookie", "kpf=PC_WEB; clientid=3; did=web_5ee38d442bc5387e413eeeefc42ed4a2; didv=1734437469000; kpn=KUAISHOU_VISION" },
        { "DNT", "1" },
        { "Host", "m.gifshow.com" },
        { "Origin", "https://m.gifshow.com" },
        { "Pragma", "no-cache" },
        // {
        //     "Referer",
        //     "https://m.gifshow.com/fw/photo/3xvfmfagspjxq9q?cc=share_copylink&kpf=PC_WEB&utm_campaign=pc_share&shareMethod=token&utm_medium=pc_share&kpn=KUAISHOU_VISION&subBiz=SINGLE_ROW_WEB&ztDid=web_126778f97e238efa29915c708f0789b6&shareId=18063407013272&shareToken=X-1KuDdzw7LGTYAM&shareMode=app&efid=0&shareObjectId=3xvfmfagspjxq9q&utm_source=pc_share"
        // },
        { "Sec-Fetch-Dest", "document" },
        { "Sec-Fetch-Mode", "navigate" },
        { "Sec-Fetch-Site", "none" },
        {
            "User-Agent",
            "Mozilla/5.0 (Linux; Android 8.0.0; SM-G955U Build/R16NW) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Mobile Safari/537.36"
        },
        { "content-type", "application/json" },
        { "sec-ch-ua", "\"Chromium\";v=\"128\", \"Not;A=Brand\";v=\"24\", \"Google Chrome\";v=\"128\"" },
        { "sec-ch-ua-mobile", "?1" },
        { "sec-ch-ua-platform", "\"Android\"" }
    };

    // https://m.gifshow.com/rest/wd/photo/info 的body数据
    private static readonly Dictionary<string, string> _requestBodyDict = new()
    {
        { "efid", "0" },
        { "shareMethod", "token" },
        { "shareChannel", "share_copylink" },
        { "kpn", "KUAISHOU_VISION" },
        { "subBiz", "SINGLE_ROW_WEB" },
        { "env", "SHARE_VIEWER_ENV_TX_TRICK" },
        { "h5Domain", "m.gifshow.com" },
        { "isLongVideo", "false" },
        // 下面的数据需要获取location中的数据
        { "shareToken", "X99ctjxn909o1jf" },
        { "shareObjectId", "3xvfmfagspjxq9q" },
        { "shareId", "18063552635341" },
        // 与shareObjectId数据一样
        { "photoId", "3xvfmfagspjxq9q" }
    };

    private readonly ILogger _logger;


    public KuaiShouShortVideoService(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    ///     解析快手
    ///     https://www.kuaishou.com/f/X-9UuzlPQN2St1Ab
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public async Task<string> ExtractUrlAsync(string text)
    {
        _logger.Information("开始解析快手链接 {text}", text);
        return text.Trim();
    }

    /// <summary>
    ///     根据链接 https://www.kuaishou.com/f/X-9UuzlPQN2St1Ab 解析出页面中的数据
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public async Task<VideoModel> ExtractVideoDataAsync(string url)
    {
        try
        {
            _logger.Information("开始解析链接 {url}", url);

            var client = new RestClient();
            var locationRequest = new RestRequest(url);

            locationRequest.AddHeaders(_locationHeaders);
            var locationResponse = client.Execute(locationRequest);

            if (locationResponse.ResponseUri is null)
            {
                _logger.Error("获取location参数失败");
                throw new InvalidDataException("获取location参数失败");
            }

            // 发送请求并获取响应
            _logger.Information("开始解析location,reponse {AbsoluteUri}", locationResponse.ResponseUri.AbsoluteUri);

            var videoRequestUrl = locationResponse.ResponseUri.AbsoluteUri.Replace("https://www.kuaishou.com/short-video", "https://m.gifshow.com/fw/photo");
            var videoRequest = new RestRequest(videoRequestUrl);
            videoRequest.AddHeaders(_videoInfoHeaders);
            var videoResponse = client.Execute(videoRequest);

            if (!videoResponse.IsSuccessful) throw new HttpRequestException("request is fail");

            var content = videoResponse.Content;
            _logger.Information("开始解析响应内容 {content}", content);
            if (content is null) throw new InvalidDataException("content is null");

            const string routerDataPattern =  @"""photo"":\s*\{(.*?)\},\s*""serialInfo""";

            var matchJson = Regex.Match(content, routerDataPattern);

            _logger.Information("开始解析匹配到的json {matchJson}", matchJson);
            if (matchJson.Groups.Count < 2) throw new InvalidDataException("未匹配到合法的数据，matchJson.Groups.Count < 2");

            var videoJson = "{"+matchJson.Groups[1].Value+"}";
            _logger.Information("开始解析匹配到的json {videoJson}", videoJson);
            // 反序列化JSON字符串为C#对象
            var videoData = JsonConvert.DeserializeObject<KuaishouShareVideoData>(videoJson);
            if (videoData is null) throw new InvalidDataException("JSON解析数据为空，请检查分享链接是否正确，如有更多问题请查看日志");
            return new VideoModel
            {
                Platform = ShortVideoPlatformEnum.KuaiShou,
                VideoId = videoData.Manifest.VideoId,
                AuthorName = videoData.UserName,
                AuthorAvatar = videoData.HeadUrl.ToString(),
                Title = videoData.Caption,
                Cover = videoData.CoverUrls.First().Url.ToString(),
                VideoUrl = videoData.MainMvUrls.First().Url.ToString(),
                Mp3Url = "",
                CreatedTime =
                    DateTimeOffset.FromUnixTimeMilliseconds(videoData.Timestamp)
                        .ToString("yyyy-MM-dd HH:mm:ss"),
                Desc = "暂无~",
                Duration = videoData.Duration.ToString(),
                DiggCount = videoData.LikeCount,
                ViewCount = videoData.ViewCount,
                CollectCount = 0,
                CommentCount = videoData.CommentCount,
                ShareCount = videoData.ShareCount
            };
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            throw;
        }
    }

    public async Task DownloadAsync(string url, string savePath, string fileName,
        EventHandler<DownloadProgressChangedEventArgs> onProgressChanged,
        EventHandler<AsyncCompletedEventArgs> onProgressCompleted)
    {
        DownloadConfiguration downloadConfiguration = new()
        {
            ChunkCount = 8, // Download in 8 chunks (increase for larger files)
            MaxTryAgainOnFailover = 5, // Retry up to 5 times on failure
            Timeout = 10000, // 10 seconds timeout for each request
            RequestConfiguration = new RequestConfiguration
            {
                UserAgent = _videoInfoHeaders.GetValueOrDefault("User-Agent")
            }
        };

        DownloadService downloader = new(downloadConfiguration);

        downloader.DownloadProgressChanged += onProgressChanged;
        downloader.DownloadFileCompleted += onProgressCompleted;

        try
        {
            await downloader.DownloadFileTaskAsync(url, savePath + fileName);
        }
        catch (Exception ex)
        {
            _logger.Information("Download failed: {ex}", ex);
            throw;
        }
    }
}