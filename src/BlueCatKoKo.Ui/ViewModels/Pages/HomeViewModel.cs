using System.ComponentModel.DataAnnotations;
using System.IO;

using BlueCatKoKo.Ui.Constants;
using BlueCatKoKo.Ui.Models;
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
        private readonly IShortVideoService _douYinShortVideoService;
        private readonly IShortVideoService _kuaiShortVideoService;
        private readonly ILogger _logger;

        // 解析出的视频数据
        [ObservableProperty] private VideoModel _data;

        // 下载进度
        [ObservableProperty] private double _downloadProcess;

        // 下载链接
        [ObservableProperty] [Required(ErrorMessage = "缺少分享链接")]
        private string _downloadUrlText;

        // 解析按钮状态，正在解析/下载时，禁止点击
        [ObservableProperty] private bool _isDisableParsingBtn;

        // 是否已经下载
        [ObservableProperty] private string _isDownload;

        // 是否下载音频,默认false
        [ObservableProperty] private bool _isDownloadAudio;

        // 是否下载视频，默认true
        [ObservableProperty] private bool _isDownloadVideo;


        // 视频是否已解析
        [ObservableProperty] private string _isParsed;

        public HomeViewModel(IMessenger messenger, ILogger logger,
            DouYinShortVideoService douYinShortVideoService,
            KuaiShouShortVideoService kuaiShortVideoService,
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
            _douYinShortVideoService = douYinShortVideoService;
            _kuaiShortVideoService = kuaiShortVideoService;
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

                if (!DownloadUrlText.Contains("https://"))
                {
                    throw new ValidationException("请输入正确的分享链接");
                }

                if (DownloadUrlText.Contains(ShortVideoPlatformEnum.DouYin.ToString().ToLower()))
                {
                    var downloadUrl = await _douYinShortVideoService.ExtractUrlAsync(DownloadUrlText);
                    Data = await _douYinShortVideoService.ExtractVideoDataAsync(downloadUrl);
                }
                else if (DownloadUrlText.Contains(ShortVideoPlatformEnum.KuaiShou.ToString().ToLower()))
                {
                    var downloadUrl = await _kuaiShortVideoService.ExtractUrlAsync(DownloadUrlText);
                    Data = await _kuaiShortVideoService.ExtractVideoDataAsync(downloadUrl);
                }
                else
                {
                    throw new ValidationException("暂不支持该平台");
                }


                // 绑定视频
                using Media media = new(LibVlc, new Uri(Data.VideoUrl));
                // 这里设置选项，防止自动播放
                MediaPlayer.Media = media;
                MediaPlayer.Pause();
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
        private void PlayOrPauseVideo()
        {
            if (!MediaPlayer.IsPlaying)
            {
                MediaPlayer.Play();
            }
            else
            {
                MediaPlayer.Pause();
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

                var filename = _appConfig.Value.DownloadPath + Data.VideoId + ".mp4";

                switch (Data.Platform)
                {
                    case ShortVideoPlatformEnum.DouYin:
                        await _douYinShortVideoService.DownloadAsync(Data.VideoUrl, _appConfig.Value.DownloadPath,
                            Data.VideoId + ".mp4",
                            (sender, e) =>
                            {
                                DownloadProcess = e.ProgressPercentage;
                            }, (sender, e) =>
                            {
                                DownloadProcess = 100;
                                message = filename + "下载成功~";
                            });
                        break;
                    case ShortVideoPlatformEnum.KuaiShou:
                        await _kuaiShortVideoService.DownloadAsync(Data.VideoUrl, _appConfig.Value.DownloadPath,
                            Data.VideoId + ".mp4",
                            (sender, e) =>
                            {
                                DownloadProcess = e.ProgressPercentage;
                            }, (sender, e) =>
                            {
                                DownloadProcess = 100;
                                message = filename + "下载成功~";
                            });
                        break;
                    default:
                        throw new ValidationException("暂不支持该平台");
                }
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