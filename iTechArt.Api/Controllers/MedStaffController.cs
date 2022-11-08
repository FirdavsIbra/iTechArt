using iTechArt.Api.Constants;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController, Route(RouteConstants.MEDSTAFF)]
    public sealed class MedStaffController : ControllerBase
    {
        private readonly IMedStaffService _medStaffService;

        public MedStaffController(IMedStaffService medStaffService)
        {
            _medStaffService = medStaffService;
        }

        /// <summary>
        /// Uploads file and saves in database
        /// </summary>
        [HttpPost(ApiConstants.IMPORT)]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                if (FileConstants.Extensions.Contains(fileExtension))
                {
                    await _medStaffService.ImportMedStaffFile(file);

                    return Ok();
                }
            }
                        
            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Uploads excel file and saves in database
        /// </summary>
        [HttpPost(ApiConstants.importExcel)]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension == ".xlsx" || fileExtension == ".xls")
                {
                    await _medStaffService.ExcelParse(file);

                    return Ok();
                }
            }

            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Uploads csv file and saves in database
        /// </summary>
        [HttpPost(ApiConstants.importCsv)]
        public async Task<IActionResult> ImportCSV(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension == ".csv")
                {
                    await _medStaffService.CSVParse(file);

                    return Ok();
                }
            }

            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Uploads xml file and saves in database
        /// </summary>
        [HttpPost(ApiConstants.importXml)]
        public async Task<IActionResult> ImportXML(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension == ".xml")
                {
                    await _medStaffService.XMLParse(file);

                    return Ok();
                }
            }

            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Gets all data from database
        /// </summary>
        [HttpGet(ApiConstants.EXPORT)]
        public async Task<IActionResult> ExportAsync([FromServices] IMedStaffService _medStaffService)
        {
            return Ok(await _medStaffService.ExportMedStaffFile());
        }
    }
}
