using BackgroundServiceExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundServiceExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BGServiceController : ControllerBase
    {
        private readonly ILogger<BGServiceController> _logger;

        private readonly IServiceProvider _provider;
        private readonly MyCustomBackgroundService _backgroundService;

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public BGServiceController(IServiceProvider provider, ILogger<BGServiceController> logger)
        {
            _provider = provider;
            _logger = logger;
            _backgroundService = provider.GetServices<IHostedService>().OfType<MyCustomBackgroundService>().Single();
        }

        [HttpPost("StartBackgroundService")]
        public async Task<IActionResult> StartBackgroundService()
        {
            await _backgroundService.StartAsync(_cancellationTokenSource.Token);
            _logger.LogInformation("BG service has been STARTED!");

            return Ok();
        }

        [HttpPost("StopBackgroundService")]
        public async Task<IActionResult> StopBackgroundService()
        {
            await _backgroundService.StopAsync(_cancellationTokenSource.Token);
            _logger.LogInformation("BG service has been STOPPED!");

            return Ok();
        }

        [HttpPost("EnableExecution")]
        public IActionResult EnableExecution()
        {
            _backgroundService.IsEnabled = true;
            _logger.LogInformation("BG service has been ENABLED!");

            return Ok();
        }

        [HttpPost("DisableExecution")]
        public IActionResult DisableExecution()
        {
            _backgroundService.IsEnabled = false;
            _logger.LogInformation("BG service has been DISABLED!");

            return Ok();
        }
    }
}
