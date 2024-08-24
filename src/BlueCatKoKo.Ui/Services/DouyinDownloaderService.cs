using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;

using BlueCatKoKo.Ui.Models;

using Downloader;

using Newtonsoft.Json;

using RestSharp;

using Serilog;

namespace BlueCatKoKo.Ui.Services
{
    public class DouyinDownloaderService
    {
        private static readonly Dictionary<string, string> _defaultHeaders = new()
        {
            {
                "User-Agent",
                "Mozilla/5.0 (Linux; Android 8.0.0; SM-G955U Build/R16NW) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Mobile Safari/537.36"
            },
            { "sec-fetch-site", "same-origin" },
            { "sec-fetch-mode", "cors" },
            { "sec-fetch-dest", "empty" },
            { "sec-ch-ua-platform", "Windows" },
            { "sec-ch-ua-mobile", "?0" },
            { "sec-ch-ua", "\"Not/A)Brand\";v=\"8\", \"Chromium\";v=\"126\", \"Google Chrome\";v=\"126\"" },
            { "referer", "https://www.douyin.com/?recommend=1" },
            { "priority", "u=1, i" },
            { "pragma", "no-cache" },
            { "cache-control", "no-cache" },
            { "accept-language", "zh-CN,zh;q=0.9,en;q=0.8" },
            {
                "accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
            },
            { "dnt", "1" }
        };

        private readonly ILogger _logger;

        public DouyinDownloaderService(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     解析dy分享中的文本 6.17 05/18 U@L.wf fbn:/ 悬疑推理：亡者和自己的手机上午一同下葬，下午却给警察发来短信 本期的故事，来自于高分推理神剧《天堂岛疑云》中的谜案《亡灵的短信》。# 悬疑推理 # 每日推荐电影
        ///     # 一剪到底  https://v.douyin.com/ircqoExo/ 复制此链接，打开Dou音搜索，直接观看视频！
        ///     https://v.douyin.com/ircqoExo/
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<string> ExtractUrlAsync(string text)
        {
            _logger.Information("开始解析文本 {text}", text);
            return Regex.Match(text, @"https?://[^\s]+").Value;
        }

        /// <summary>
        ///     根据链接 https://v.douyin.com/ircqoExo/ 解析出页面中的数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<DouyinShareRouterData?> ExtractVideoDataAsync(string url)
        {
            try
            {
                _logger.Information("开始解析链接 {url}", url);
                // 创建RestClient
                RestClient client = new RestClient(url);

                // 创建请求对象
                RestRequest request = new RestRequest();

                // 设置 User-Agent 模拟手机浏览器
                request.AddHeaders(_defaultHeaders);

                // 发送请求并获取响应
                RestResponse response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    throw new HttpRequestException("request is fail");
                }

                string? content = response.Content;
                _logger.Information("开始解析响应内容 {content}", content);
                if (content is null)
                {
                    throw new InvalidDataException("content is null");
                }

                const string routerDataPattern = @"_ROUTER_DATA\s*=\s*(\{.*?\});";

                Match matchJson = Regex.Match(content, routerDataPattern);

                _logger.Information("开始解析匹配到的json {matchJson}", matchJson);
                if (matchJson.Groups.Count < 2)
                {
                    throw new InvalidDataException("未匹配到合法的数据，matchJson.Groups.Count < 2");
                }

                string videoJson = matchJson.Groups[1].Value;
                _logger.Information("开始解析匹配到的json {videoJson}", videoJson);
                // 反序列化JSON字符串为C#对象
                return JsonConvert.DeserializeObject<DouyinShareRouterData>(videoJson);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                throw;
            }
        }

        public async Task Download(string url, string savePath, string fileName,
            EventHandler<DownloadProgressChangedEventArgs> onProgressChanged,
            EventHandler<AsyncCompletedEventArgs> onProgressCompleted
        )
        {
            var downloadConfiguration = new DownloadConfiguration
            {
                ChunkCount = 8, // Download in 8 chunks (increase for larger files)
                MaxTryAgainOnFailover = 5, // Retry up to 5 times on failure
                Timeout = 10000, // 10 seconds timeout for each request
                RequestConfiguration = new RequestConfiguration()
                {
                    UserAgent = _defaultHeaders.GetValueOrDefault("User-Agent"),
                }
            };

            var downloader = new DownloadService(downloadConfiguration);

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
}