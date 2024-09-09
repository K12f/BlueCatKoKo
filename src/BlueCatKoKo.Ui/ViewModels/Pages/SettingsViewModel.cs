using BlueCatKoKo.Ui.Models;
using BlueCatKoKo.Ui.Services;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using Microsoft.Extensions.Options;
using Microsoft.Win32;

using Serilog;

namespace BlueCatKoKo.Ui.ViewModels.Pages
{
    [ObservableRecipient]
    public partial class SettingsViewModel : ViewModelBase
    {
        private readonly IOptions<AppConfig> _appConfig;
        private readonly AppConfigService _appConfigService;
        private readonly ILogger _logger;

        [ObservableProperty] private string _downloadPath;

        public SettingsViewModel(IMessenger messenger, ILogger logger,
            IOptions<AppConfig> appConfig, AppConfigService appConfigService)
        {
            Messenger = messenger;
            IsActive = true;

            _logger = logger;
            _appConfig = appConfig;
            _appConfigService = appConfigService;

            DownloadPath = _appConfig.Value.DownloadPath ?? "./";
        }

        [RelayCommand]
        private void SelectDownloadPath()
        {
            // Configure open folder dialog box
            OpenFolderDialog dialog = new() { Multiselect = false };
            if (dialog.ShowDialog() == true)
            {
                // 获取用户选择的目录路径
                string selectedPath = dialog.FolderName + "/";
                DownloadPath = selectedPath;
                _appConfig.Value.DownloadPath = selectedPath;

                _appConfigService.Write(_appConfig.Value);
            }
        }
    }
}