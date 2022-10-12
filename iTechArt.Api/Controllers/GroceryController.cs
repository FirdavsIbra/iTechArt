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

        [HttpPost("import")]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && (formFile.ContentType.Contains("csv") || formFile.ContentType.Contains("officedocument.spreadsheetml.sheet")))
            {
                return Ok(_groceryService.ImportGrocery());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        [HttpGet("export")]
        public IActionResult Export() 
        {
            return Ok(_groceryService.ExportGrocery());
        }
    }
}
