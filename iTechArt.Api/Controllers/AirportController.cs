using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [Route("api/airport")]
    [ApiController]
    public sealed class AirportController : ControllerBase
    {
        private readonly IAirportsService _airportsService;
        public AirportController(IAirportsService airportsService)
        {
            _airportsService = airportsService;
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportAirportExcel(IFormFile file)
        {
            if (file != null && (file.ContentType.EndsWith("xlsx") || file.ContentType.Contains("officedocument.spreadsheetml.sheet")))
            {
                return Ok(await _airportsService.ImportAirportExcel());
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportAirportExcel()
        {
            return Ok(await _airportsService.ExportAirportExcel());
        }
    }
}
