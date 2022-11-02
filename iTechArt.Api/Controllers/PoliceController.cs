using iTechArt.Api.Constants;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route(RouteConstants.POLICE)]
    public sealed class PoliceController : ControllerBase
    {
        private readonly IPoliceService _policeService;

        public PoliceController(IPoliceService policeService)
        {
            _policeService = policeService;
        }



        /// <summary>
        /// route: api/police/import. Takes csv or xlsx file
        /// Uploads data about Police and saves in database
        /// </summary>
        /// <param name="file"></param>
        [HttpPost(ApiConstants.IMPORT)]
        public async Task<IActionResult> Import(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            if (file != null)
            {
                if (FileConstants.Extensions.Contains(fileExtension) || FileConstants.EXCEL.Contains(file.ContentType)
                    || FileConstants.CSV.Contains(file.ContentType) || FileConstants.XML.Contains(file.ContentType))
                {
                    await _policeService.ImportPoliceData(file);
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid file format!");
                }
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        /// <summary>
        /// route: api/police/export
        /// Gets all data about police from the database
        /// </summary>
        [HttpGet(ApiConstants.EXPORT)]
        public IActionResult Export()
        {
            return Ok(_policeService.ExportPoliceData());
        }
    }
}