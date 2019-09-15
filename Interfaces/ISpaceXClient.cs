using System.Collections.Generic;
using System.Threading.Tasks;
using LaunchpadChallenge.Models;

namespace LaunchpadChallenge.Interfaces
{
    public interface ISpaceXClient
    {
        Task<List<Launchpad>> RetrieveApiData();
    }
}