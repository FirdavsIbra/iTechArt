using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Async method takes no parameters and returns serialized entities as file
        /// </summary>
        /// <returns>returns IFormFile</returns>
        public IStudent[] ExportStudentsAsync()
        {
            return _studentRepository.GetAll();
        }

        /// <summary>
        /// Async method that takes IFormFile as parameter and saves entities into DB
        /// </summary>
        /// <returns></returns>
        public IStudent[] ImportStudentsAsync()
        {
            return _studentRepository.GetAll();
        }
    }
}
