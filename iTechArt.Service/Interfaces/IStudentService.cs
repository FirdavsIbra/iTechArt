using Microsoft.AspNetCore.Http;

namespace iTechArt.Service.Interfaces
{
    public interface IStudentService
    {
        void ImportStudent(IFormFile formFile);
        IFormFile ExportStudent();
    }
}
