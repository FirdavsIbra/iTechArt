using iTechArt.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IActionResult> Import(IFormFile formFile)
        {
            if (formFile != null && (_allowedTypes.Contains<string>(formFile.ContentType)))
            {
                await _studentsService.ImportStudentsAsync(formFile);
                return Ok();
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
