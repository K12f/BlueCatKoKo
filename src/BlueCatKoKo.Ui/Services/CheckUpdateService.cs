using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlueCatKoKo.Ui.Services;

public class CheckUpdateService : BackgroundService
{
    private readonly ILogger<CheckUpdateService> _logger;

    public CheckUpdateService(ILogger<CheckUpdateService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);

            _logger.LogInformation("Checking for updated");
        }
    }
}