using iTechArt.Domain.ServiceInterfaces;

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
        /// <returns></returns>
        public List<string> ImportStudentsAsync()
        {
            return new List<string>();
        }
    }
}
