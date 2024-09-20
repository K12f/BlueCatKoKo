using MicaSetup.Design.Controls;
using MicaSetup.Services;
using MicaSetup.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: Guid("00000000-0000-0000-0000-000000000000")]
[assembly: AssemblyTitle("BlueCatKoKo Uninst")]
[assembly: AssemblyProduct("BlueCatKoKo")]
[assembly: AssemblyDescription("BlueCatKoKo Uninst")]
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
            .UseAsUninst()
            .UseLogger(false)
            .UseSingleInstance("MicaSetup")
            .UseTempPathFork()
            .UseElevated()
            .UseDpiAware()
            .UseOptions(option =>
            {
                option.IsCreateDesktopShortcut = true;
                option.IsCreateUninst = true;
                option.IsCreateRegistryKeys = true;
                option.IsCreateStartMenu = true;
                option.IsCreateQuickLaunch = false;
                option.IsCreateAsAutoRun = false;
                option.IsUseRegistryPreferX86 = null!;
                option.IsAllowFirewall = true;
                option.IsRefreshExplorer = true;
                option.IsInstallCertificate = false;
                option.ExeName = "BlueCatKoKo.exe";
                option.KeyName = "BlueCatKoKo";
                option.DisplayName = "BlueCatKoKo";
                option.DisplayIcon = "BlueCatKoKo.exe";
                option.DisplayVersion = "1.5.0";
                option.Publisher = "K12f";
                option.AppName = "BlueCatKoKo";
                option.SetupName = $"BlueCatKoKo {Mui("UninstallProgram")}";
                option.MessageOfPage1 = "BlueCatKoKo";
                option.MessageOfPage2 = Mui("ProgressTipsUninstalling");
                option.MessageOfPage3 = Mui("UninstallFinishTips");
            })
            .UseServices(service =>
            {
                service.AddSingleton<IMuiLanguageService, MuiLanguageService>();
                service.AddScoped<IExplorerService, ExplorerService>();
            })
            .CreateApp()
            .UseMuiLanguage()
            .UseTheme(WindowsTheme.Auto)
            .UsePages(page =>
            {
                page.Add(nameof(MainPage), typeof(MainPage));
                page.Add(nameof(UninstallPage), typeof(UninstallPage));
                page.Add(nameof(FinishPage), typeof(FinishPage));
            })
            .UseDispatcherUnhandledExceptionCatched()
            .UseDomainUnhandledExceptionCatched()
            .UseUnobservedTaskExceptionCatched()
            .RunApp();
    }
}
