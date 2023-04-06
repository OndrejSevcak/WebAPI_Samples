namespace BackgroundServiceExample.Services
{
    public class MyCustomBackgroundService : BackgroundService
    {
        private readonly ILogger<MyCustomBackgroundService> _logger;
        private readonly IMyExecutionService _service;
        private int _executionCount = 0;

        public bool IsEnabled { get; set; } = false;

        public MyCustomBackgroundService(ILogger<MyCustomBackgroundService> logger, IMyExecutionService service)
        {
            _logger = logger;
            _service = service;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (IsEnabled)
                {
                    _executionCount++;
                    _logger.LogInformation($"Background service is running execution number: {_executionCount}");

                    await _service.DoSomeWork();
                }
                else
                {
                    _logger.LogInformation("Background service running but not enabled! Sleeping for 10s now.");
                    await Task.Delay(10_000);
                }

            }
            _executionCount = 0;
        }
    }
}
