using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using launchpad_challenge.Interfaces;
using launchpad_challenge.Models;

namespace launchpad_challenge.Repositories
{
    public class LaunchpadRepo: ILaunchpadRepo
    {
        public async Task<List<Launchpad>> RetrieveLaunchpadDataFromDatabase()
        {
            throw new NotImplementedException();
        }   
    }
}