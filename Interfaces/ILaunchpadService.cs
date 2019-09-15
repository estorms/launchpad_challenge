using System.Collections.Generic;
using System.Threading.Tasks;
using LaunchpadChallenge.Models;

namespace LaunchpadChallenge.Interfaces
{
    public interface ILaunchpadService
    {
        Task<List<Launchpad>> RetrieveData();
        bool IsExternalApi();
    }
}