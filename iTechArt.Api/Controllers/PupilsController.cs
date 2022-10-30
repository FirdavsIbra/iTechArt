using iTechArt.Api.Constants;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route(RouteConstants.PUPIL)]
    public sealed class PupilsController : ControllerBase
    {
        private readonly IPupilService _pupilService;
        public PupilsController(IPupilService pupilService)
        {
            _pupilService = pupilService;
        }

        /// <summary>
        /// Upload pupil's file
        /// </summary>
        [HttpPost(ApiConstants.IMPORT)]
        public async Task<IActionResult> Import(IFormFile formFile)
        {
            if (formFile != null)
            {
                var fileExtension = Path.GetExtension(formFile.FileName);

                if (FileConstants.Extensions.Contains(fileExtension))
                {
                    await _pupilService.ImportPupilsFileAsync(formFile);
                    return Ok("Success");
                }

                return BadRequest("Invalid file format!");
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        /// <summary>
        /// Get all pupils
        /// </summary>
        [HttpGet("export")]
        public IActionResult GetAllAsync()
        {
            return Ok(_pupilService.GetAllAsync());
        }

        /// <summary>
        /// Get pupil by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(await _pupilService.GetByIdAsync(id));
        }
    }
}
