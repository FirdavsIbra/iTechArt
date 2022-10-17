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

        [HttpPost(StaticDetails.Import)]
        public IActionResult Import(IFormFile formFile)
        {
            var fileExtensions = new string[] {".csv", ".xlsx", "officedocument.spreadsheetml.sheet", ".xls"};
            if (formFile != null && fileExtensions.Contains<string>(formFile.ContentType))
            {
                return Ok(_policeService.ImportPolice());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        [HttpGet(StaticDetails.Export)]
        public IActionResult Export()
        {
            return Ok(_policeService.ExportPolice());
        }
    }
}
