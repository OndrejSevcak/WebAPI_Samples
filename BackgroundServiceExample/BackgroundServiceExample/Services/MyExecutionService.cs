namespace BackgroundServiceExample.Services
{
    public class MyExecutionService : IMyExecutionService
    {
        private readonly ILogger<MyExecutionService> _logger;

        public MyExecutionService(ILogger<MyExecutionService> logger)
        {
            _logger = logger;
        }

        public async Task DoSomeWork()
        {
            await Task.Run(() =>
            {
                _logger.LogInformation("DoSomeWork method of MyExecutionService is running...");
                Thread.Sleep(10_000);
                _logger.LogInformation("DoSomeWork method of MyExecutionService has finished...");
            });
        }
    }
}
