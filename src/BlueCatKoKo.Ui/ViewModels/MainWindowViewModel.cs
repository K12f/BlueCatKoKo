using System.Collections.ObjectModel;
using BlueCatKoKo.Ui.Constants;
using BlueCatKoKo.Ui.Models;
using BlueCatKoKo.Ui.Views.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using HandyControl.Controls;
using HandyControl.Data;
using Microsoft.Extensions.Options;
using Serilog;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BlueCatKoKo.Ui.ViewModels;

[ObservableRecipient]
public partial class MainWindowViewModel : ViewModelBase, IRecipient<ValueChangedMessage<DownloaderMessage>>
{
    private readonly IOptions<AppConfig> _appConfig;
    private readonly ILogger _logger;
    private readonly INavigationService _navigationService;

    [ObservableProperty] private string _applicationTitle = string.Empty;
    [ObservableProperty] private string _applicationTrayTitle = string.Empty;

    private bool _isInitialized;

    [ObservableProperty] private ObservableCollection<object> _navigationFooter = [];

    [ObservableProperty] private ObservableCollection<object> _navigationItems = [];

    [ObservableProperty] private ObservableCollection<MenuItem> _trayMenuItems = [];

    public MainWindowViewModel(INavigationService navigationService, IOptions<AppConfig> appConfig, ILogger logger,
        IMessenger messenger)
    {
        Messenger = messenger;
        IsActive = true;

        _navigationService = navigationService;

        _appConfig = appConfig;

        _logger = logger;

        ApplicationTitle = _appConfig.Value.Name ?? "";
        ApplicationTrayTitle = _appConfig.Value.TrayTitle ?? "";
        if (!_isInitialized) InitializeViewModel();
    }

    public void Receive(ValueChangedMessage<DownloaderMessage> message)
    {
        var type = message.Value.Type;
        var notifyMessage = message.Value.Message;
        var url = message.Value.Url;
        var growlInfo = new GrowlInfo { Message = notifyMessage, ShowDateTime = true, WaitTime = 2 };

        _logger.Information("Receive: {Type}, Message: {Message}, Url: {Url}", type, notifyMessage, url);

        // 使用 switch 表达式
        switch (type)
        {
            case DownloaderEnum.Init or DownloaderEnum.Downloading:
                Growl.Info(growlInfo);
                break;
            case DownloaderEnum.Success:
                Growl.Success(growlInfo);
                break;
            case DownloaderEnum.Warning:
                Growl.Warning(growlInfo);
                break;
            case DownloaderEnum.Error:
                Growl.Error(growlInfo);
                break;
            default:
                // 记录未知类型的信息
                Growl.Warning(growlInfo);
                break;
        }
    }

    private void InitializeViewModel()
    {
        NavigationItems =
        [
            new NavigationViewItem
            {
                Content = "首页",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(HomePage)
            },
            // new NavigationViewItem
            // {
            //     Content = "视频",
            //     Icon = new SymbolIcon { Symbol = SymbolRegular.Video20 },
            //     TargetPageType = typeof(VideoPage)
            // },
            // new NavigationViewItem
            // {
            //     Content = "Cookie管理",
            //     Icon = new SymbolIcon { Symbol = SymbolRegular.Cookies16 },
            //     TargetPageType = typeof(CookiesPage)
            // },
            new NavigationViewItem
            {
                Content = "关于",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Person12 },
                TargetPageType = typeof(AboutPage)
            }
        ];

        NavigationFooter =
        [
            new NavigationViewItem
            {
                Content = "设置",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(SettingsPage)
            }
        ];

        _isInitialized = true;
    }
}