using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [Route("api/students")]
    [ApiController]
    public sealed class StudentsController : ControllerBase
    {
        private readonly string[] _allowedTypes = new string[] {"csv", "officedocument.spreadsheetml.sheet" };
        private readonly IStudentsService _studentsService;
        public StudentsController(IStudentsService studentService)
        {
            _studentsService = studentService;
        }

        /// <summary>
        /// route: api/students/import. Takes csv or xlsx file and injects into IStudentService.ImportStudentAsync(IFormFile) 
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns>if successful returns Status200OK, otherwise Status400BadRequest</returns>
        [HttpPost("import")]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && (formFile.ContentType.Contains("csv") || formFile.ContentType.Contains("officedocument.spreadsheetml.sheet")))
            {
                return Ok(_studentsService.ImportStudentsAsync());
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        /// <summary>
        /// route: api/students/export. Returns Status200OK
        /// </summary>
        /// <returns></returns>
        [HttpGet("export")]
        public async Task<IActionResult> Export()
        {
            return Ok(await _studentsService.ExportStudentsAsync());
        }
    }
}
