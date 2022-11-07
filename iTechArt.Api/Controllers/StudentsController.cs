using iTechArt.Api.Constants;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    /// <summary>
    /// route: "api/students"
    /// </summary>
    [Route(RouteConstants.STUDENTS)]
    [ApiController]
    public sealed class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;
        public StudentsController(IStudentsService studentService)
        {
            _studentsService = studentService;
        }

        /// <summary>
        /// Takes csv or xlsx file
        /// </summary>
        [HttpPost(ApiConstants.IMPORT)]
        public async Task<IActionResult> Import(IFormFile file)
        {
            var allowedTypes = FileConstants.Extensions;
            if (file != null && allowedTypes.Contains(Path.GetExtension(file.FileName)))
            {
                await _studentsService.ImportStudentsAsync(file);
                return Ok();
            }
            else
            {
                return BadRequest("Invalid file type!");
            }
        }

        /// <summary>
        /// Get all students
        /// </summary>
        [HttpGet()]
        public async Task<ActionResult<IStudent[]>> GetAllAsync()
        {
            return Ok(await _studentsService.ExportStudentsAsync());
        }

        /// <summary>
        /// Parse student's file from excel
        /// </summary>
        [HttpPost(ApiConstants.IMPORTSTUDENTEXCEL)]
        public async Task<IActionResult> ImportExcelFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _studentsService.ExcelImportAsync(file);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Parse student's file from csv
        /// </summary>
        [HttpPost(ApiConstants.IMPORTSTUDENTCSV)]
        public async Task<IActionResult> ImportCsvFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _studentsService.CsvImportAsync(file);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Parse student's file from xml
        /// </summary>
        [HttpPost(ApiConstants.IMPORTSTUDENTXML)]
        public async Task<IActionResult> ImportXmlFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _studentsService.XmlImportAsync(file);
                return Ok();
            }
            return BadRequest();
        }
    }
}
