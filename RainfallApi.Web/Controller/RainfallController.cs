
using Microsoft.AspNetCore.Mvc;
using RainfallApi.Application.Interfaces;
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
            _rainfallService = rainfallService ?? throw new ArgumentNullException(nameof(rainfallService));
        }

        [HttpGet("id/{stationId}/readings")]
        public async Task<ActionResult<RainfallReadingResponse>> GetRainfallReadings(string stationId, [FromQuery] int count = 10)
        {
            var result = await _rainfallService.GetRainfallReadingsAsync(stationId, count);
            return result;
        }
    }
}
