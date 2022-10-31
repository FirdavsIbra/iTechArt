using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.Constants;
using Microsoft.AspNetCore.Http;

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
        public async Task<IStudents[]> ExportStudentsAsync()
        {
            return _studentRepository.GetAll();
        }

        /// <summary>
        /// Async method that saves entities into DB
        /// </summary>
        public async Task ImportStudentsAsync(IFormFile formFile)
        {
            var fileExtension = Path.GetExtension(formFile.FileName);

            if (fileExtension == ".xlsx")
            {
                await ExcelImporter(formFile);
            }
            else if (fileExtension == ".csv")
            {
                await CsvImporter(formFile);
            }
            else if (fileExtension == ".xml")
            {
                await XmlImporter(formFile);
            }
            else
            {
                throw new Exception("wrong file extention");
            }
        }

        private async Task XmlImporter(IFormFile formFile)
        {
            throw new NotImplementedException();
        }

        private async Task CsvImporter(IFormFile formFile)
        {
            throw new NotImplementedException();
        }

        private async Task ExcelImporter(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}
