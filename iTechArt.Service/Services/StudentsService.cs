using iTechArt.Service.Interfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Service.Services
{
    public class StudentsService : IStudentsService
    {
        /// <summary>
        /// Async method takes no parameters and returns serialized entities as file
        /// </summary>
        /// <returns>returns IFormFile</returns>
        public async Task<List<string>> ExportStudentsAsync()
        {
            var obj = new List<string>();
            return obj;
        }
        /// <summary>
        /// Async method that takes IFormFile as parameter and saves entities into DB
        /// </summary>
        /// <param name="formFile"></param>
        public async Task ImportStudentsAsync(IFormFile formFile)
        {

        }
    }
}
