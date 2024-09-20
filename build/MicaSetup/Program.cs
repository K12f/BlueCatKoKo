using MicaSetup.Design.Controls;
using MicaSetup.Services;
using MicaSetup.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: Guid("00000000-0000-0000-0000-000000000000")]
[assembly: AssemblyTitle("BlueCatKoKo Setup")]
[assembly: AssemblyProduct("BlueCatKoKo")]
[assembly: AssemblyDescription("BlueCatKoKo Setup")]
[assembly: AssemblyCompany("K12f")]
[assembly: AssemblyCopyright("Under MIT License. Copyright (c) K12f Contributors.")]
[assembly: AssemblyVersion("0.1.2.0")]
[assembly: AssemblyFileVersion("0.1.2.0")]

namespace MicaSetup;

internal class Program
{
    [STAThread]
    internal static void Main()
    {
        Hosting.CreateBuilder()
            .UseLogger(false)
            .UseSingleInstance("MicaSetup")
            .UseTempPathFork()
            .UseElevated()
            .UseDpiAware()
            .UseOptions(option =>
            {
                option.IsCreateDesktopShortcut = true;
                option.IsCreateUninst = true;
                option.IsCreateStartMenu = true;
                option.IsCreateQuickLaunch = false;
                option.IsCreateRegistryKeys = true;
                option.IsCreateAsAutoRun = false;
                option.IsCustomizeVisiableAutoRun = true;
                option.AutoRunLaunchCommand = "-autostart";
                option.UseFolderPickerPreferClassic = false;
                option.UseInstallPathPreferX86 = false;
                option.IsUseRegistryPreferX86 = null!;
                option.IsAllowFullFolderSecurity = true;
                option.IsAllowFirewall = true;
                option.IsRefreshExplorer = true;
                option.IsInstallCertificate = false;
                option.OverlayInstallRemoveExt = "exe,dll,pdb";
                option.UnpackingPassword = null!;
                option.ExeName = @"BlueCatKoKo.exe";
                option.KeyName = "BlueCatKoKo";
                option.DisplayName = "BlueCatKoKo";
                option.DisplayIcon = "BlueCatKoKo.exe";
                option.DisplayVersion = "1.5.0";
                option.Publisher = "K12f";
                option.AppName = "BlueCatKoKo";
                option.SetupName = $"BlueCatKoKo {Mui("Setup")}";
                option.MessageOfPage1 = "BlueCatKoKo";
                option.MessageOfPage2 = Mui("Installing");
                option.MessageOfPage3 = Mui("InstallFinishTips");
            })
            .UseServices(service =>
            {
                service.AddSingleton<IMuiLanguageService, MuiLanguageService>();
                service.AddScoped<IDotNetVersionService, DotNetVersionService>();
                service.AddScoped<IExplorerService, ExplorerService>();
            })
            .CreateApp()
            .UseMuiLanguage()
            .UseTheme(WindowsTheme.Auto)
            .UsePages(page =>
            {
                page.Add(nameof(MainPage), typeof(MainPage));
                page.Add(nameof(InstallPage), typeof(InstallPage));
                page.Add(nameof(FinishPage), typeof(FinishPage));
            })
            .UseDispatcherUnhandledExceptionCatched()
            .UseDomainUnhandledExceptionCatched()
            .UseUnobservedTaskExceptionCatched()
            .RunApp();
    }
}
