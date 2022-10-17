using iTechArt.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route("grocery")]
    public class GroceryController : Controller
    {
        private readonly IGroceryService _groceryService;
        public GroceryController(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }

        [HttpPost(StaticDetails.Import)]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && (formFile.ContentType.Contains(FileExt.FILE_CSV) || formFile.ContentType.Contains(FileExt.FILE_XLSX) || formFile.ContentType.Contains(FileExt.FILE_SPREADSHEET)))
            {
                return Ok(_groceryService.ImportGrocery());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }


        [HttpGet(StaticDetails.Export)]
        public IActionResult Export()
        {
            return Ok(_groceryService.ExportGrocery());
        }
    }
}
