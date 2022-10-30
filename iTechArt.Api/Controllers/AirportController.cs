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
        private readonly string[] excelExtensions = {".xlsx", ".xls", ".xlsm", ".xlsb", ".xltx", ".xltm", ".xlt", ".xlam", ".xla", ".xlw" };

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
            var fileExtension = Path.GetExtension(file.FileName);

            if (excelExtensions.Contains(fileExtension))
            {
                await _airportsService.ImportAirportExcel(file);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Controller of Exporting airport data
        /// </summary>
        [HttpGet(ApiConstants.EXPORT)]
        public async Task<IActionResult> ExportAirportExcel()
        {
            return Ok(_airportsService.ExportAirportExcel());
        }
    }
}
