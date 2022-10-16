using iTechArt.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController, Route("api/medStaff")]
    public sealed class MedStaffController : ControllerBase
    {
        public readonly IMedStaffService medStaffService;

        public MedStaffController(IMedStaffService medStaffService)
        {
            this.medStaffService = medStaffService;
        }

        [HttpPost("import")]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && (formFile.ContentType.Contains("csv") || formFile.ContentType.Contains("officedocument.spreadsheetml.sheet")))
            {
                return Ok(medStaffService.ImportMedStaffFile());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        [HttpGet("export")]
        public IActionResult Export()
        {
            return Ok(medStaffService.ExportMedStaffFile());
        }
    }
}
