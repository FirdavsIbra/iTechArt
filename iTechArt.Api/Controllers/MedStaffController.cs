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
        public async ValueTask<IActionResult> Import(IFormFile formFile)
        {
            if (formFile != null)
            {
                if (FileConstants.CSV.Contains(formFile.ContentType.ToLower()))
                {
                    return Ok();
                }
                else if (FileConstants.XML.Contains(formFile.ContentType.ToLower()))
                {
                    return Ok();
                }
                else if (FileConstants.EXCEL.Contains(formFile.ContentType.ToLower()))
                {
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
