using System.Collections.Generic;
using System.Threading.Tasks;
using launchpad_challenge.Models;

namespace launchpad_challenge.Interfaces
{
    public interface ILaunchpadService
    {
        Task<List<Launchpad>> RetrieveData();
        Task<List<Launchpad>> RetrieveLaunchpadFromDatabase();
        Task<List<Launchpad>> RetrieveApiData();
    }
}