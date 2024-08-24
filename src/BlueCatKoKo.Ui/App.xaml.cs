using System.Windows;
using System.Windows.Threading;

using BlueCatKoKo.Ui.Models;
using BlueCatKoKo.Ui.Services;
using BlueCatKoKo.Ui.ViewModels;
using BlueCatKoKo.Ui.ViewModels.Pages;
using BlueCatKoKo.Ui.Views;
using BlueCatKoKo.Ui.Views.Pages;

using CommunityToolkit.Mvvm.Messaging;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Serilog;

using Wpf.Ui;

using HomeViewModel = BlueCatKoKo.Ui.ViewModels.Pages.HomeViewModel;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace BlueCatKoKo.Ui
{
    using HomeViewModel = ViewModels.Pages.HomeViewModel;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly IHost _host = Host.CreateDefaultBuilder()
            .ConfigureHostConfiguration(builder =>
            {
                // builder.AddJsonFile("appsettings.json");
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();
                logging.Services.AddSingleton(Log.Logger);
            })
            .ConfigureServices((context, container) =>
            {
                container.AddHostedService<ApplicationHostService>();
                // configuration
                container.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
                container.AddSingleton<AppConfigService>();

                // Service containing 
                container.AddSingleton<INavigationService, NavigationService>();
                container.AddSingleton<DouyinDownloaderService>();

                // Main window with navigation
                container.AddSingleton<MainWindowViewModel>();
                container.AddSingleton<INavigationWindow, MainWindow>();


                //view and viewmodels
                container.AddSingleton<HomePage>();
                container.AddSingleton<HomeViewModel>();

                container.AddSingleton<VideoPage>();
                container.AddSingleton<VideoViewModel>();

                container.AddSingleton<CookiesPage>();
                container.AddSingleton<CookiesViewModel>();

                container.AddSingleton<SettingsPage>();
                container.AddSingleton<SettingsViewModel>();

                container.AddSingleton<AboutPage>();
                container.AddSingleton<AboutViewModel>();

                // messager
                container.AddSingleton<WeakReferenceMessenger>();
                container.AddSingleton<IMessenger>(sp => sp.GetRequiredService<WeakReferenceMessenger>());

                container.AddSingleton(_ => Current.Dispatcher);
            }).Build();

        public static new App Current => (App)Application.Current;

        /// <summary>
        ///     Gets services.
        /// </summary>
        public static IServiceProvider Services => _host.Services;


        /// <summary>
        ///     Occurs when the application is loading.
        /// </summary>
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
        }

        /// <summary>
        ///     Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
        }

        /// <summary>
        ///     Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}