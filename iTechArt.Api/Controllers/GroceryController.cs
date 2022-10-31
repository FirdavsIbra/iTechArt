using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route("api/grocery")]
    public sealed class GroceryController : Controller
    {
        private readonly IGroceryService _groceryService;
        private readonly string[] fileExtensions = { "xlsx", "xls", "csv", "application/vnd.ms-excel", "officedocument.spreadsheetml.sheet" };

        public GroceryController(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }
        /// <summary>
        /// api route which applies the following extensions
        /// will allow to upload the data from file to db 
        /// </summary>
        [HttpPost(ApiConstants.IMPORT)]
        public async Task<IActionResult> Import(IFormFile formFile)
        {

            if(formFile != null && formFile.ContentType.Contains("csv")) 
            {
                return Ok(await _groceryService.RecordCsvToDatabase(formFile));
            }
            else if (formFile != null && formFile.ContentType.Contains("officedocument.spreadsheetml.sheet")) 
            {
                return Ok(await _groceryService.RecordXlsxToDatabase(formFile));
            }
            else
                return BadRequest("Invalid file format!");
        }
        /// <summary>
        /// api route which allows to get all info from db and parse it to the following format
        /// </summary>
        [HttpGet(ApiConstants.EXPORT)]
        public IActionResult Export()
        {
            return Ok(_groceryService.ExportGrocery());
        }
        /// <summary>
        /// Get count of grocery not implemented yet
        /// </summary>
        [HttpGet(ApiConstants.GETCOUNTOFGROCERY)]
        public IActionResult GetCountOfGrocery()
        {
            return Ok(_groceryService.GetCountOfGrocery());
        }
    }
}
