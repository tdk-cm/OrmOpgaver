using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using OpgaverApi.Sections.StarWars;
using OpgaverApi.Sections.StarWars.Models;
using OpgaverApi.Sections.StarWars.Processors;
using System.Net;
using System.Text.RegularExpressions;

namespace OpgaverApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StarWarsController : ControllerBase
    {
        [Route("Test")]
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            try
            {
                return Ok("test");
            }
            catch (Exception ex)
            {
                return base.StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }

        }

        [Route("SolveExcercise")]
        [HttpGet]
        public async Task<IActionResult> SolveOpgave(int opgaveId)
        {
            try
            {

                PlanetProcessor p = PlanetProcessor.Instance;
                List<Planet> returnList = p.Solve(opgaveId);

                
                return Ok(returnList.Select(x => x.Name));
            }
            catch (Exception ex)
            {
                return base.StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }

        }
    }
}
