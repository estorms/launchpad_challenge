using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using launchpad_challenge.Interfaces;
using launchpad_challenge.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace launchpad_challenge.Services
{
    public class LaunchpadService: ILaunchpadService
    {
        private readonly ILogger<LaunchpadService> _logger;
        private readonly IConfiguration _config;
        private readonly bool _isExternalApi;
        public LaunchpadService(ILogger<LaunchpadService> logger, IConfiguration config)
        {
            _config = config;
            _logger = logger;
            _isExternalApi = IsExternalApi();
        }
        public async Task<List<Launchpad>> RetrieveData()
        {
            if (_isExternalApi)
                return await RetrieveApiData();
            return await RetrieveLaunchpadFromDatabase();
        }

        public async Task<List<Launchpad>> RetrieveLaunchpadFromDatabase()
        {
            throw new NotImplementedException();
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
        private bool IsExternalApi()
        {
            //TODO: This should not be reliant on casting a string value; too brittle. Better solution, Liz
            var source = _config.GetValue<string>("IsExternalAPI:Value");
           return bool.Parse(source);
        }
    }
}