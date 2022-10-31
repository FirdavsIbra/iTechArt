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
        /// <param name="formFile"></param>
        /// <returns>if successful returns Status200OK, otherwise Status400BadRequest</returns>
        [HttpPost(ApiConstants.IMPORT)]
        public async Task<IActionResult> Import(IFormFile formFile)
        {
            var allowedTypes = FileConstants.Extensions;
            if (formFile != null && allowedTypes.Contains(Path.GetExtension(formFile.FileName)))
            {
                await _studentsService.ImportStudentsAsync(formFile);
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
