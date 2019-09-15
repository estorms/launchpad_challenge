using System.Collections.Generic;
using System.Threading.Tasks;
using launchpad_challenge.Models;

namespace launchpad_challenge.Interfaces
{
    public interface ILaunchpadRepo
    {
        Task<List<Launchpad>> RetrieveLaunchpadDataFromDatabase();
    }
}