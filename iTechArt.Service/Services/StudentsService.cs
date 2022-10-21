using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public class StudentsService : IStudentsService
    {
        /// <summary>
        /// Async method takes no parameters and returns serialized entities as file
        /// </summary>
        public async Task<List<string>> ExportStudentsAsync()
        {
            return new List<string>();
        }

        /// <summary>
        /// Async method that saves entities into DB
        /// </summary>
        public async Task<List<string>> ImportStudentsAsync()
        {
            return new List<string>();
        }
    }
}
