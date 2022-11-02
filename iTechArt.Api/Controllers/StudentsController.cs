using iTechArt.Api.Constants;
using iTechArt.Domain.ServiceInterfaces;
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
        /// route: api/students/import. Takes csv or xlsx file and injects into IStudentService.ImportStudentAsync(IFormFile) 
        /// </summary>
        /// <param name="file"></param>
        /// <returns>if successful returns Status200OK, otherwise Status400BadRequest</returns>
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
        /// route: api/students/export. Returns Status200OK
        /// </summary>
        [HttpGet(ApiConstants.EXPORT)]
        public async Task<IActionResult> Export()
        {
            return Ok(await _studentsService.ExportStudentsAsync());
        }
    }
}
