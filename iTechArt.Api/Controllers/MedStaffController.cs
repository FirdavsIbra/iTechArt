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

        private static readonly string[] extensions = { "csv", "officedocument.spreadsheetml.sheet", "xlsx" };

        [HttpPost("import")]
        public async ValueTask<IActionResult> Import(IFormFile formFile)
        {
            if (formFile != null && extensions.Contains(formFile.ContentType))
            {
                return Ok(await medStaffService.ImportMedStaffFile());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportAsync()
        {
            return Ok(await medStaffService.ExportMedStaffFile());
        }
    }
}
