using iTechArt.Domain.ModelInterfaces;
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

        /// <summary>
        /// Upload pupil's file
        /// </summary>
        /// <param name="formFile"></param>
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

        /// <summary>
        /// Get all pupils
        /// </summary>
        [HttpGet("export")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(_pupilService.GetAllAsync());
        }

        /// <summary>
        /// Get pupil by id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] long id)
        {
            return Ok(await _pupilService.GetByIdAsync(id));
        }
        
        /// <summary>
        /// Delete pupil
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _pupilService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(IPupil pupil)
        {
            await _pupilService.AddAsync(pupil);
            return Ok();
        }

    }
}
