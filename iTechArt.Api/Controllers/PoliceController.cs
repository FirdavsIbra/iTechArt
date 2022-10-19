using iTechArt.Domain.ServiceInterfaces;
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

        [HttpPost(StaticDetails.IMPORT)]
        public IActionResult Import(IFormFile formFile)
        {
            var fileExtensions = new string[] { ".application/vnd.ms-excel", ".xlsx", "officedocument.spreadsheetml.sheet", ".xls"};

            if (formFile != null && (formFile.ContentType.Contains("application/vnd.ms-excel") || formFile.ContentType.Contains("officedocument.spreadsheetml.sheet")))
            {
                return Ok(_policeService.ImportPolice());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        [HttpGet(StaticDetails.EXPORT)]
        public IActionResult Export()
        {
            return Ok(_policeService.ExportPolice());
        }
    }
}
