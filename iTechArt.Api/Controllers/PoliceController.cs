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
        private readonly string[] fileExtensions = new string[] { ".csv", ".xlsx", ".xls" };
        private readonly string[] contentTypes = new string[] { "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" };

        public PoliceController(IPoliceService policeService)
        {
            _policeService = policeService;
        }

        /// <summary>
        /// route: api/police/import. Takes csv or xlsx file
        /// Uploads data about Police and saves in database
        /// </summary>
        /// <param name="formFile"></param>
        [HttpPost(ApiConstants.IMPORT)]
        public IActionResult Import(IFormFile formFile)
        {
            string fileExtension = Path.GetExtension(formFile.FileName);

            if (formFile != null)
            {
                if (fileExtensions.Contains(fileExtension) || contentTypes.Contains(formFile.ContentType))
                {
                    return Ok(_policeService.ImportPoliceData());
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