using iTechArt.Service.Interfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Service.Services
{
    public class StudentService : IStudentService
    {
        public IFormFile ExportStudent()
        {
            return new object() as IFormFile;
        }

        public void ImportStudent(IFormFile formFile)
        {

        }
    }
}
