using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route("api/pupils")]
    public sealed class PupilsController : ControllerBase
    {
        private readonly IPupilService _pupilService;
        public PupilsController(IPupilService pupilService)
        {
            _pupilService = pupilService;
        }

        [HttpPost("import")]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && (formFile.ContentType.Contains("application/vnd.ms-excel") || formFile.ContentType.Contains("officedocument.spreadsheetml.sheet")))
            {
                return Ok(_pupilService.ImportPupilsFile());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        [HttpGet("export")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _pupilService.GetAllAsync());
        }
    }
}
