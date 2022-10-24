using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route("api/grocery")]
    public sealed class GroceryController : Controller
    {
        private readonly IGroceryService _groceryService;
        private readonly string[] fileExtensions = { ".xlsx", ".xls", ".csv", "application/vnd.ms-excel", "officedocument.spreadsheetml.sheet" };

        public GroceryController(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }
        /// <summary>
        /// api route which applies the following extensions
        /// will allow to upload the data from file to db 
        /// </summary>
        [HttpPost(ApiConstants.IMPORT)]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && (fileExtensions.Any(fileExtensions => !formFile.ContentType.Contains(fileExtensions))))
            {
                return Ok(_groceryService.ImportGrocery());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }
        /// <summary>
        /// api route which allows to get all info from db and parse it to the following format
        /// </summary>
        [HttpGet(ApiConstants.EXPORT)]
        public IActionResult Export()
        {
            return Ok(_groceryService.ExportGrocery());
        }
    }
}
