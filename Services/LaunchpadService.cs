using System.Collections.Generic;
using System.Threading.Tasks;
using LaunchpadChallenge.Interfaces;
using LaunchpadChallenge.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LaunchpadChallenge.Services
{
    public class LaunchpadService : ILaunchpadService
    {
        private readonly ILogger<LaunchpadService> _logger;
        private readonly IConfiguration _config;
        private readonly ISpaceXClient _spaceXClient;
        private readonly ILaunchpadRepo _launchpadRepo;
        private readonly bool _isExternalApi;

        //TODO: Injecting both repo and client is bloat, esp. if they become microservices. Decouple further.
        public LaunchpadService(ILogger<LaunchpadService> logger, IConfiguration config, ILaunchpadRepo launchpadRepo,
            ISpaceXClient spaceXClient)
        {
            _config = config;
            _logger = logger;
            _launchpadRepo = launchpadRepo;
            _spaceXClient = spaceXClient;
            _isExternalApi = IsExternalApi();
        }
        public async Task<List<Launchpad>> RetrieveData()
        {
            if (_isExternalApi)
            {
                _logger.LogInformation("Retrieving launchpad data from SpaceX API");
                return await _spaceXClient.RetrieveApiData();
            }

            _logger.LogInformation("Retrieving launchpad data from database");
            return await _launchpadRepo.RetrieveLaunchpadDataFromDatabase();
        }
        //TODO: Don't love relying on casting a string value; feels brittle. Better solution, Liz.
        public bool IsExternalApi()
        {
            var source = _config.GetValue<string>("IsExternalAPI:Value");
            return bool.Parse(source);
        }
    }
}