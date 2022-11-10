using iTechArt.Api.Constants;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route(RouteConstants.POLICE)]
    public sealed class PoliceController : ControllerBase
    {
        private readonly IPoliceService _policeService;

        public PoliceController(IPoliceService policeService)
        {
            _policeService = policeService;
        }

        /// <summary>
        /// route: api/police/import. Takes xlsx.
        /// Uploads xslx data about Police and saves in database.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTEXCEL)]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension == FileConstants.xlsx || fileExtension == FileConstants.xls)
                {
                    await _policeService.ImportExcel(file);
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid file format!");
                }
            }
            else
            {
                return BadRequest("No input found!");
            }
        }


        /// <summary>
        /// route: api/police/import. Takes xml.
        /// Uploads xml data about Police and saves in database.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTXML)]
        public async Task<IActionResult> ImportXml(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            if (file != null && fileExtension == FileConstants.xml)
            {
                await _policeService.ImportXml(file);
                return Ok();
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        /// <summary>
        /// route: api/police/import. Takes csv.
        /// Uploads csv data about Police and saves in database.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTCSV)]
        public async Task<IActionResult> ImportCsv(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            if (file != null && fileExtension == FileConstants.csv)
            {
                await _policeService.ImportCsv(file);
                return Ok();
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        /// <summary>
        /// route: api/police/export.
        /// Gets all data about police from the database.
        /// </summary>
        [HttpGet("get_all")]
        public async Task<ActionResult<IPolice[]>> GetAllData()
        {
            return Ok(await _policeService.GetAllPolice());
        }
    }
}