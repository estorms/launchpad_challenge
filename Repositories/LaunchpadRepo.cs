using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaunchpadChallenge.Interfaces;
using LaunchpadChallenge.Models;

namespace LaunchpadChallenge.Repositories
{
    public class LaunchpadRepo: ILaunchpadRepo
    {
        public async Task<List<Launchpad>> RetrieveLaunchpadDataFromDatabase()
        {
            throw new NotImplementedException();
        }   
    }
}