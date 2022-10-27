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
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null)
            {
                if (FileConstants.EXCEL.Contains(formFile.ContentType.ToLower()) || 
                    FileConstants.CSV.Contains(formFile.ContentType.ToLower()) ||
                    FileConstants.XML.Contains(formFile.ContentType.ToLower()))
                {
                    return Ok();
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
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _pupilService.GetAllAsync());
        }

        /// <summary>
        /// Get pupil by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(await _pupilService.GetByIdAsync(id));
        }
        
        /// <summary>
        /// Delete pupil
        /// </summary>
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAsync(long id)
        //{
        //    await _pupilService.DeleteAsync(id);
        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddAsync(IPupil pupil)
        //{
        //    await _pupilService.AddAsync(pupil);
        //    return Ok();
        //}

    }
}
