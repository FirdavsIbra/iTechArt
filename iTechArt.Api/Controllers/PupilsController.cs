using iTechArt.Api.Constants;
using iTechArt.Domain.ModelInterfaces;
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
        public async Task<ActionResult> Import(IFormFile file)
        {
            if (file != null)
            {
                var fileExtension = Path.GetExtension(file.FileName);

                if (FileConstants.Extensions.Contains(fileExtension))
                {
                    await _pupilService.ImportPupilsFileAsync(file);
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
        [HttpGet()]
        public async Task<ActionResult<IPupil[]>> GetAllAsync()
        {
            return Ok(await _pupilService.GetAllAsync());
        }

        /// <summary>
        /// Get pupil by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<IPupil>> GetByIdAsync(long id)
        {
            return Ok(await _pupilService.GetByIdAsync(id));
        }

        /// <summary>
        /// Parse pupil's file from excel
        /// </summary>
        [HttpPost(ApiConstants.IMPORTPUPILEXCEL)]
        public async Task<ActionResult> ImportExcelFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _pupilService.ImportExcelAsync(file);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Parse pupil's file from csv
        /// </summary>
        [HttpPost(ApiConstants.IMPORTPUPILCSV)]
        public async Task<ActionResult> ImportCsvFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _pupilService.ImportCsvAsync(file);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Parse pupil's file from xml
        /// </summary>
        [HttpPost(ApiConstants.IMPORTPUPILXML)]
        public async Task<ActionResult> ImportXmlFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _pupilService.ImportXmlAsync(file);
                return Ok();
            }
            return BadRequest();
        }
    }
}
