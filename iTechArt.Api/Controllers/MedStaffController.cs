using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController, Route("api/medStaff")]
    public sealed class MedStaffController : ControllerBase
    {
        public readonly IMedStaffService _medStaffService;
        private static readonly string[] extensions = { "application/vnd.ms-excel", "officedocument.spreadsheetml.sheet", "xlsx" };

        public MedStaffController(IMedStaffService medStaffService)
        {
            _medStaffService = medStaffService;
        }

        /// <summary>
        /// Uploads file and saves in database
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns> An Array of Repository Models </returns>
        [HttpPost("import")]
        public async ValueTask<IActionResult> Import(IFormFile formFile)
        {
            if (formFile != null && (formFile.ContentType.Contains("application/vnd.ms-excel") || formFile.ContentType.Contains("officedocument.spreadsheetml.sheet")))
            {
                return Ok(_medStaffService.ImportMedStaffFile());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        /// <summary>
        /// Gets all data from database
        /// </summary>
        [HttpGet("export")]
        public async Task<IActionResult> ExportAsync()
        {
            return Ok(_medStaffService.ExportMedStaffFile());
        }
    }
}
