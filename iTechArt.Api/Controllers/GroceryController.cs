using iTechArt.Api.Constants;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route(RouteConstants.GROCERIES)]
    public sealed class GroceryController : Controller
    {
        private readonly IGroceryService _groceryService;
        private const string CSV = "csv";
        private const string Excel = "officedocument.spreadsheetml.sheet";
        private const string XML = "xml";

        public GroceryController(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }
        /// <summary>
        /// api route which applies the following extensions
        /// will allow to upload the data from file to db 
        /// </summary>
        [HttpPost(ApiConstants.IMPORT)]
        public async Task<IActionResult> Import(IFormFile file)
        {

            if(file != null && file.ContentType.Contains(CSV)) 
            {
                return Ok(await _groceryService.RecordCsvToDatabase(file));
            }
            else if (file != null && file.ContentType.Contains(Excel)) 
            {
                return Ok(await _groceryService.RecordXlsxToDatabase(file));
            }
            else if (file != null && file.ContentType.Contains(XML))
            {
                return Ok(await _groceryService.RecordXmlToDatabase(file));
            }
            else
                return BadRequest("Invalid file format!");
        }
        /// <summary>
        /// api route which allows to get all info from db and parse it to the following format
        /// </summary>
        [HttpGet(ApiConstants.EXPORT)]
        public async Task<IActionResult> Export()
        {
            return Ok(await _groceryService.ExportGrocery());
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
