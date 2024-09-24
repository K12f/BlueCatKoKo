using System.IO;
using BlueCatKoKo.Ui.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace BlueCatKoKo.Ui.Services;

/// <summary>
/// 配置服务
/// </summary>
public class AppConfigService
{
    private readonly ILogger _logger;
    private readonly ReaderWriterLockSlim _rwLock = new();
    private const string _appSettingsFile = "appsettings.json";

    private static string StartUpPath { get; set; } = AppContext.BaseDirectory;

    public AppConfigService(ILogger logger)
    {
        _logger = logger;
    }

    private static string Absolute(string relativePath)
    {
        return Path.Combine(StartUpPath, relativePath);
    }

    public void Write(AppConfig config)
    {
        _rwLock.EnterWriteLock();
        try
        {
            var path = Absolute(config.DownloadPath ?? "./");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            var file = Path.Combine(StartUpPath, _appSettingsFile);
            _logger.Information("保存配置文件:{file}", file);
            _logger.Information("保存配置内容:{@config}", config);
            var appSettings = File.ReadAllText(file);
            var appSettingsObj = JObject.Parse(appSettings);
            appSettingsObj[nameof(AppConfig)] = JsonConvert.SerializeObject(config);
            File.WriteAllText(file, appSettingsObj.ToString());
        }
        catch (Exception e)
        {
            _logger.Error("保存配置文件失败:{error}", e.Message);
        }
        finally
        {
            _rwLock.ExitWriteLock();
        }
    }
}