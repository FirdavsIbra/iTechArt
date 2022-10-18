using iTechArt.Api.Constans;
using iTechArt.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route("api/grocery")]
    public sealed class GroceryController : Controller
    {
        private readonly IGroceryService _groceryService;
        public GroceryController(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }

        [HttpPost(RouteConstants.IMPORT)]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && (formFile.ContentType.Contains(FileExt.FILE_CSV)
                || formFile.ContentType.Contains(FileExt.FILE_XLSX)
                || formFile.ContentType.Contains(FileExt.FILE_SPREADSHEET)))
            {
                return Ok(_groceryService.ImportGrocery());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }


        [HttpGet(RouteConstants.EXPORT)]

        public IActionResult Export()
        {
            return Ok(_groceryService.ExportGrocery());
        }
    }
}
