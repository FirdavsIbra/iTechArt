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
        public IStudent[] ExportStudentsAsync()
        {
            return _studentRepository.GetAll();
        }

        /// <summary>
        /// Async method that saves entities into DB
        /// </summary>
        public IStudent[] ImportStudentsAsync()
        {
            return _studentRepository.GetAll();
        }
    }
}
