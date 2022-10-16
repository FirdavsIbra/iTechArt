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

        private string[] extentions = { "csv", "officedocument.spreadsheetml.sheet" };

        [HttpPost("import")]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && extentions.Contains(formFile.ContentType))
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
