using Newtonsoft.Json;

namespace BlueCatKoKo.Ui.Models;

public class AppLogging
{
    [JsonProperty("LogLevel")] public LogLevel LogLevel { get; set; }
}

public class LogLevel
{
    [JsonProperty("Microsoft")] public string Microsoft { get; set; }

    [JsonProperty("Default")] public string Default { get; set; }

    [JsonProperty("System")] public string System { get; set; }
}