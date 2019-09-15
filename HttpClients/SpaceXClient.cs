using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LaunchpadChallenge.Interfaces;
using LaunchpadChallenge.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LaunchpadChallenge.HttpClients
{
    public class SpaceXClient: ISpaceXClient
    {
        private readonly ILogger<SpaceXClient> _logger;
        private readonly IConfiguration _config;

        public SpaceXClient(ILogger<SpaceXClient> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        public async Task<List<Launchpad>> RetrieveApiData()
        {
            using (var client = new HttpClient())
            {
                var requestPath = _config.GetValue<string>("ConnectionStrings:LaunchpadExternalAPI");
                var response = await client.GetAsync(requestPath);
                response.EnsureSuccessStatusCode();
                _logger.LogInformation("API request for launchpad data successful.");
                var stringResponse = await response.Content.ReadAsStringAsync();
                return DeserializeResponse(stringResponse);
            }
        }
        private List<Launchpad> DeserializeResponse(string response)
        {
            return JsonConvert.DeserializeObject<Launchpad[]>(response).ToList();
        }
    }
}