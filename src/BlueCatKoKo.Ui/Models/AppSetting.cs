// YApi QuickType插件生成，具体参考文档:https://plugins.jetbrains.com/plugin/18847-yapi-quicktype/documentation

using Newtonsoft.Json;

namespace BlueCatKoKo.Ui.Models;

public class AppSetting
{
    [JsonProperty("Logging")] public AppLogging AppLogging { get; set; }

    [JsonProperty("AppConfig")] public AppConfig AppConfig { get; set; }
}