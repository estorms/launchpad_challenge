using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace launchpad_challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchpadController : Controller
    
    {
   
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"https://api.spacexdata.com/v2/launchpads");
                    response.EnsureSuccessStatusCode();
                    var stringResult = await response.Content.ReadAsStringAsync();
                    return Ok(new List<string> {stringResult});
                }
                catch (Exception ex)
                {
                    switch (ex)
                    {
                        case Exception ex_:
                            return NotFound();
                        default:
                            return NotFound();
                    }
                }
            }
        }
    }
}
