using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [Route("api/students")]
    [ApiController]
    public sealed class StudentsController : ControllerBase
    {
        private readonly string[] _allowedTypes = new string[] { "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" };
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
        [HttpPost(ApiConstants.IMPORT)]
        public IActionResult Import(IFormFile formFile)
        {
            if (formFile != null && _allowedTypes.Contains(formFile.ContentType))
            {
                return Ok(_studentsService.ImportStudentsAsync());
            }
            else
            {
                return BadRequest("Invalid file type!");
            }
        }

        /// <summary>
        /// route: api/students/export. Returns Status200OK
        /// </summary>
        [HttpGet(ApiConstants.EXPORT)]
        public async Task<IActionResult> Export()
        {
            return Ok(_studentsService.ExportStudentsAsync());
        }
    }
}
