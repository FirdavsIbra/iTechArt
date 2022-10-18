using Microsoft.AspNetCore.Http;

namespace iTechArt.Service.Interfaces
{
    public interface IStudentsService
    {
        public Task ImportStudentsAsync(IFormFile formFile);
        public Task<List<string>> ExportStudentsAsync();
        
    }
}
