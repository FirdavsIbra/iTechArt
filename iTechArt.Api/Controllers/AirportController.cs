using iTechArt.Api.Constants;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [Route(RouteConstants.AIRPORT)]
    [ApiController]
    public sealed class AirportController : ControllerBase
    {
        private readonly IAirportsService _airportsService;

        public AirportController(IAirportsService airportsService)
        {
            _airportsService = airportsService;
        }

        /// <summary>
        /// Controller of Importing airport data
        /// </summary>
        /// <param name="file"></param>
        [HttpPost(ApiConstants.IMPORT)]
        public async Task<IActionResult> ImportAirportExcel(IFormFile file)
        {
            if (file != null)
            {
                var fileExtension = Path.GetExtension(file.FileName);

                if (FileConstants.Extensions.Contains(fileExtension))
                {
                    await _airportsService.ImportAirportFile(file);
                    return Ok();
                }

                return BadRequest("Invalid file format!");
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        /// <summary>
        /// Controller of Exporting airport data
        /// </summary>
        [HttpGet(ApiConstants.EXPORT)]
        public async Task<IActionResult> ExportAirportExcel()
        {
            return Ok( await _airportsService.ExportAirportExcel());
        }
    }
}
