using System;
using System.Threading.Tasks;
using LaunchpadChallenge.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LaunchpadChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchpadController : Controller
    {
        private readonly ILogger<LaunchpadController> _logger;
        private readonly ILaunchpadService _launchpadService;

        public LaunchpadController(ILogger<LaunchpadController> logger, ILaunchpadService launchpadService)
        {
            _logger = logger;
            _launchpadService = launchpadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _launchpadService.RetrieveData();
                return Ok(data);
            }
            catch (Exception ex)
            {
                //TODO: This should be middleware with far more granular logging and accurate status codes
                _logger.LogError($"Exception {ex} encountered");
                return NotFound();
            }
        }
    }
}