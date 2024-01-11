
using Microsoft.AspNetCore.Mvc;
using RainfallApi.Application.Services;
//using RainfallApi.Core.Models;
using System.Threading.Tasks;

namespace RainfallApi.Web.Controllers
{
    [ApiController]
    [Route("rainfall")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallService _rainfallService;

        public RainfallController(IRainfallService rainfallService)
        {
            _rainfallService = rainfallService;
        }

        [HttpGet("/rainfall/id/{stationId}/readings")]
        public async Task<ActionResult<RainfallReadingResponse>> GetRainfallReadings(string stationId, [FromQuery] int count = 10)
        {
            var result = await _rainfallService.GetRainfallReadingsAsync(stationId, count);
            return Ok(result);
        }
    }
}
