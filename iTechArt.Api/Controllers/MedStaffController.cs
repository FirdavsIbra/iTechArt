using iTechArt.Api.Constants;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController, Route("api/medStaff")]
    public sealed class MedStaffController : ControllerBase
    {
        /// <summary>
        /// Uploads file and saves in database
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns> An Array of Repository Models </returns>
        [HttpPost("import")]
        public async ValueTask<IActionResult> Import([FromServices] IMedStaffService _medStaffService, IFormFile formFile)
        {
            if (formFile != null)
            {
                string fileExtension = Path.GetExtension(formFile.FileName);

                if (FileConstants.Extensions.Contains(fileExtension))
                {
                    await _medStaffService.ImportMedStaffFile(formFile);

                    return Ok();
                }
            }
                        
            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Gets all data from database
        /// </summary>
        [HttpGet("export")]
        public async Task<IActionResult> ExportAsync([FromServices] IMedStaffService _medStaffService)
        {
            return Ok(await _medStaffService.ExportMedStaffFile());
        }
    }
}
