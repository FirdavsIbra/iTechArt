using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route("api/police")]
    public sealed class PoliceController : ControllerBase
    {
        private readonly IPoliceService _policeService;
        private readonly string[] fileExtensions = new string[] { "application/vnd.ms-excel", ".xlsx", "officedocument.spreadsheetml.sheet", ".xls", ".csv" };
        
        public PoliceController(IPoliceService policeService)
        {
            _policeService = policeService;
        }

        [HttpPost(ApiConstants.IMPORT)]
        public IActionResult Import(IFormFile formFile)
        {
            string fileExtension = Path.GetExtension(formFile.FileName);
            
            if(fileExtensions.Contains(fileExtension))
            {
                return Ok(_policeService.ImportPoliceData());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        [HttpGet(ApiConstants.EXPORT)]
        public IActionResult Export()
        {
            return Ok(_policeService.ExportPoliceData());
        }
    }
}