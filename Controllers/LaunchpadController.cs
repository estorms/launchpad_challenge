using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using launchpad_challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace launchpad_challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchpadController : Controller
    {
        private ILogger<LaunchpadController> _logger;
        private IConfiguration _config;
        private bool _isExternalAPI;

        public LaunchpadController(ILogger<LaunchpadController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _isExternalAPI = IsExternalAPI();

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"https://api.spacexdata.com/v2/launchpads");
                    response.EnsureSuccessStatusCode();
                    _logger.LogInformation("Request for launchpad data successful.");
                    
                    //TODO: Abstract out into service layer; API should not transform data or apply business logic

                    var json = await response.Content.ReadAsStringAsync();
                    var deserializedJson = JsonConvert.DeserializeObject<Launchpad[]>(json).ToList();
                    _logger.LogInformation("Successfully deserialized request.");
                    return Ok(deserializedJson);
                }
                catch (Exception ex)
                {
                    switch (ex)
                    {
                        case Exception _:
                            return NotFound();
                        default:
                            return NotFound();
                    }
                }
            }
        }

        private bool IsExternalAPI()
        {
            //TODO: This should not be reliant on a string value; too brittle. XML config with int?
            var source = _config.GetValue<string>("DataSource:Source");
           return source == "ExternalAPI";
        }
    }
}
