using iTechArt.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route("api/pupils")]
    public class PupilsController : ControllerBase
    {
        private readonly IPupilService _pupilService;
        public PupilsController(IPupilService pupilService)
        {
            _pupilService = pupilService;
        }

        [HttpPost("import")]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && (formFile.ContentType.Contains("csv") || formFile.ContentType.Contains("officedocument.spreadsheetml.sheet")))
            {
                return Ok(_pupilService.ImportPupilsFile());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        [HttpGet("export")]
        public IActionResult Export()
        {
            return Ok(_pupilService.ExportPupilsFile());
        }
    }
}
