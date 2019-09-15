using System.Collections.Generic;
using System.Threading.Tasks;
using LaunchpadChallenge.Models;

namespace LaunchpadChallenge.Interfaces
{
    public interface ILaunchpadRepo
    {
        Task<List<Launchpad>> RetrieveLaunchpadDataFromDatabase();
    }
}