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

        [HttpPost(StaticDetails.Import)]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && FileExt.fileExt.Contains<string>(formFile.ContentType))
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
