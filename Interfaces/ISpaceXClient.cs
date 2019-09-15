using System.Collections.Generic;
using System.Threading.Tasks;
using launchpad_challenge.Models;

namespace launchpad_challenge.Interfaces
{
    public interface ISpaceXClient
    {
        Task<List<Launchpad>> RetrieveApiData();
        List<Launchpad> DeserializeResponse(string response);
    }
}