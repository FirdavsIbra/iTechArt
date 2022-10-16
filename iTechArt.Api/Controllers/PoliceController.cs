using iTechArt.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route("api/police")]
    public sealed class PoliceController : ControllerBase
    {
        private readonly IPoliceService _policeService;
        public PoliceController(IPoliceService policeService)
        {
            _policeService = policeService;
        }

        [HttpPost("import")]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && (formFile.ContentType.Contains("csv") || formFile.ContentType.Contains("officedocument.spreadsheetml.sheet")))
            {
                return Ok(_policeService.ImportPolice());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        [HttpGet("export")]
        public IActionResult Export()
        {
            return Ok(_policeService.ExportPolice());
        }
    }
}
