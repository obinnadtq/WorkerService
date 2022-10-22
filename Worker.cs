namespace WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("http://webapi/status");
            _logger.LogInformation($"Response: {response}");
            await Task.Delay(5000, stoppingToken);
        }
    }
}
