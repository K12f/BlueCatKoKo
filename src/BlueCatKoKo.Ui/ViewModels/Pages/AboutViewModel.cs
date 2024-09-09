using System.Diagnostics;

using BlueCatKoKo.Ui.Models;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Extensions.Options;

using Serilog;

namespace BlueCatKoKo.Ui.ViewModels.Pages
{
    public partial class AboutViewModel : ViewModelBase
    {
        private readonly IOptions<AppConfig> _appConfig;
        private readonly ILogger _logger;

        [ObservableProperty] private string _aboutText;

        [ObservableProperty] private string _currentVersion;

        [ObservableProperty] private string _repositoryUrl;

        public AboutViewModel(ILogger logger,
            IOptions<AppConfig> appConfig)
        {
            _logger = logger;
            _appConfig = appConfig;

            CurrentVersion = _appConfig.Value.Version;
            RepositoryUrl = _appConfig.Value.RepositoryUrl;

            AboutText = @"
  1.本软件只提供视频解析，不提供任何资源上传、存储到服务器的功能。
  2.本软件仅解析来自抖音的内容，不会对解析到的音视频进行二次编码，部分视频会进行有限的格式转换、拼接等操作 。
  3.本软件解析得到的所有内容均来自抖音UP主上传、分享，其版权均归原作者所有。内容提供者、上传者(UP主)应对其提供、上传的内容承担全部表任。
  4.本软件提供的所有资源，仅可用作学习交流使用，未经原作者授权，禁止用于其他用途。请在下载24小时内删除。为尊重作者版权，请前往资源的原
    始发布网站观看，支持原创，谢谢，
  5.任何涉及商业盈利目的均不得使用，否则产生的一切后果将由您自己承担。
  6.因使用本软件产生的版权问题，软件作者概不负表。";
        }

        [RelayCommand]
        private void OpenRepository(string parameter)
        {
            // 使用默认浏览器打开链接
            Process.Start(new ProcessStartInfo(RepositoryUrl + parameter) { UseShellExecute = true });
        }
    }
}