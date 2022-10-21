using iTechArt.Domain.ServiceInterfaces;
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
            if (formFile != null && (formFile.ContentType.Contains("application/vnd.ms-excel") || formFile.ContentType.Contains("officedocument.spreadsheetml.sheet")))
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
