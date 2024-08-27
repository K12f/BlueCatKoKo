using System.ComponentModel.DataAnnotations;
using System.IO;

using BlueCatKoKo.Ui.Constants;
using BlueCatKoKo.Ui.Models;
using BlueCatKoKo.Ui.Models.Pages;
using BlueCatKoKo.Ui.Services;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

using LibVLCSharp.Shared;

using Microsoft.Extensions.Options;

using Serilog;

using MediaPlayer = LibVLCSharp.Shared.MediaPlayer;

namespace BlueCatKoKo.Ui.ViewModels.Pages
{
    [ObservableRecipient]
    public partial class HomeViewModel : ViewModelBase
    {
        private readonly IOptions<AppConfig> _appConfig;
        private readonly DouyinDownloaderService _douyinDownloaderService;
        private readonly ILogger _logger;

        // 解析出的视频数据
        [ObservableProperty] private HomePageModel _data;

        // 下载进度
        [ObservableProperty] private double _downloadProcess;

        // 下载链接
        [ObservableProperty] [Required(ErrorMessage = "缺少分享链接")]
        private string _downloadUrlText;

        // 是否已经下载
        [ObservableProperty] private string _isDownload;

        // 解析按钮状态，正在解析/下载时，禁止点击
        [ObservableProperty] private bool _isDisableParsingBtn;

        // 是否下载音频,默认false
        [ObservableProperty] private bool _isDownloadAudio;

        // 是否下载视频，默认true
        [ObservableProperty] private bool _isDownloadVideo;


        // 视频是否已解析
        [ObservableProperty] private string _isParsed;

        public HomeViewModel(IMessenger messenger, ILogger logger, DouyinDownloaderService douyinDownloaderService,
            IOptions<AppConfig> appConfig)
        {
            Messenger = messenger;
            IsActive = true;

            IsParsed = "Hidden";

            IsDownloadAudio = false;
            IsDownloadVideo = true;

            IsDownload = "Hidden";
            IsDisableParsingBtn = true;


            _logger = logger;
            _douyinDownloaderService = douyinDownloaderService;
            _appConfig = appConfig;


            LibVlc = new LibVLC();
            MediaPlayer = new MediaPlayer(LibVlc);
            MediaPlayer.EnableMouseInput = true;
            //通过设置宽高比为窗体宽高可达到视频铺满全屏的效果
            MediaPlayer.AspectRatio = MediaPlayerWidth + ":" + MediaPlayerHeight;
        }

        public MediaPlayer MediaPlayer { get; init; }
        public LibVLC LibVlc { get; init; }
        public int MediaPlayerWidth => 480;
        public int MediaPlayerHeight => 400;

        [RelayCommand]
        private async Task Parse()
        {
            ValidateAllProperties();
            IsDisableParsingBtn = false;
            string message = "解析成功~";
            DownloaderEnum type = DownloaderEnum.Success;

            try
            {
                if (HasErrors)
                {
                    string errorMessage = string.Join(Environment.NewLine, GetErrors());
                    throw new ValidationException(errorMessage);
                }

                if (!DownloadUrlText.Contains("https://v.douyin.com"))
                {
                    throw new ValidationException("请输入正确的分享链接");
                }

                string downloadUrl = await _douyinDownloaderService.ExtractUrlAsync(DownloadUrlText);
                DouyinShareRouterData? douYinRouterData =
                    await _douyinDownloaderService.ExtractVideoDataAsync(downloadUrl);
                if (douYinRouterData is null)
                {
                    throw new InvalidDataException("解析数据为空，请检查分享链接是否正确，如有更多问题请查看日志");
                }

                // 获取数据 
                ItemList videoInfoData = douYinRouterData.LoaderData.VideoIdPage.VideoInfoRes.ItemList.First();

                Data = new HomePageModel
                {
                    VideoId = videoInfoData.AwemeId,
                    AuthorName = videoInfoData.Author.Nickname,
                    AuthorAvatar = videoInfoData.Author.AvatarThumb.UrlList.First().ToString(),
                    Title = videoInfoData.Author.Signature,
                    Cover = videoInfoData.Video.Cover.UrlList.Last().ToString(),
                    VideoUrl = videoInfoData.Video.PlayAddr.UrlList.First().ToString().Replace("playwm", "play"),
                    Mp3Url = "",
                    CreatedTime =
                        DateTimeOffset.FromUnixTimeSeconds(videoInfoData.CreateTime)
                            .ToString("yyyy-MM-dd HH:mm:ss"),
                    Desc = videoInfoData.Desc,
                    Duration = "",
                    DiggCount = videoInfoData.Statistics.DiggCount,
                    CollectCount = videoInfoData.Statistics.CollectCount,
                    CommentCount = videoInfoData.Statistics.CommentCount,
                    ShareCount = videoInfoData.Statistics.ShareCount
                };

                // 绑定视频
                using (Media media = new(LibVlc, new Uri(Data.VideoUrl)))
                {
                    MediaPlayer.Play(media);
                }
            }
            catch (Exception ex)
            {
                type = DownloaderEnum.Warning;
                message = ex.Message;
            }
            finally
            {
                IsDisableParsingBtn = true;
                IsParsed = "Visible";
                DownloaderMessage downloadMessage = new(type, message, DownloadUrlText);
                Messenger.Send(new ValueChangedMessage<DownloaderMessage>(downloadMessage));
            }
        }

        [RelayCommand]
        private async Task DownloadAll()
        {
            IsDownload = "Visible";
            IsDisableParsingBtn = false;

            string message = "下载中...";
            DownloaderEnum type = DownloaderEnum.Success;
            try
            {
                if (string.IsNullOrEmpty(_appConfig.Value.DownloadPath))
                {
                    throw new InvalidDataException("请在配置文件中设置下载路径");
                }

                if (string.IsNullOrEmpty(Data.VideoUrl))
                {
                    throw new InvalidDataException("无效的下载链接");
                }

                string filename = _appConfig.Value.DownloadPath + Data.VideoId + ".mp4";
                await _douyinDownloaderService.Download(Data.VideoUrl, _appConfig.Value.DownloadPath,
                    Data.VideoId + ".mp4",
                    (sender, e) =>
                    {
                        DownloadProcess = e.ProgressPercentage;
                    }, (sender, e) =>
                    {
                        DownloadProcess = 100;
                        message = filename + "下载成功~";
                    });
            }
            catch (Exception ex)
            {
                type = DownloaderEnum.Warning;
                message = ex.Message;
                _logger.Error($"DownloadException: {message}");
            }
            finally
            {
                IsDownload = "hidden";
                IsDisableParsingBtn = true;
                DownloaderMessage downloadMessage = new(type, message, DownloadUrlText);
                Messenger.Send(new ValueChangedMessage<DownloaderMessage>(downloadMessage));
            }
        }
    }
}