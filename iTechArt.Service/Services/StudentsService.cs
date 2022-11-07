using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Service.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentParsers _studentParsers;
        public StudentsService(IStudentRepository studentRepository, IStudentParsers studentParsers)
        {
            _studentRepository = studentRepository;
            _studentParsers = studentParsers;
        }

        /// <summary>
        /// Async method takes no parameters and returns serialized entities as file
        /// </summary>
        public async Task<IStudent[]> ExportStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        /// <summary>
        /// Async method that saves entities into DB
        /// </summary>
        public async Task ImportStudentsAsync(IFormFile formFile)
        {
            var fileExtension = Path.GetExtension(formFile.FileName);

            if (fileExtension == ".xlsx")
            {
                await ExcelImportAsync(formFile);
            }
            else if (fileExtension == ".csv")
            {
                await CsvImportAsync(formFile);
            }
            else if (fileExtension == ".xml")
            {
                await XmlImportAsync(formFile);
            }
            else
            {
                throw new Exception("wrong file extention");
            }
        }

        public async Task XmlImportAsync(IFormFile formFile)
        {
            await _studentParsers.XmlParseAsync(formFile);
        }

        public async Task CsvImportAsync(IFormFile formFile)
        {
            await _studentParsers.CsvParseAsync(formFile);
        }

        public async Task ExcelImportAsync(IFormFile formFile)
        {
            await _studentParsers.XmlParseAsync(formFile);
        }
    }
}
