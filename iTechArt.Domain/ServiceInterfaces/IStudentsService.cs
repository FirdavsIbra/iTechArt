using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IStudentsService
    {
        /// <summary>
        /// Imports students into DB from file
        /// </summary>
        public Task ImportStudentsAsync(IFormFile formFile);

        /// <summary>
        /// Exports students from DB
        /// </summary>
        public Task<IStudent[]> ExportStudentsAsync();
    }
}
