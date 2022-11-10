using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Service.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentParser _studentParsers;
        public StudentsService(IStudentRepository studentRepository, IStudentParser studentParsers)
        {
            _studentRepository = studentRepository;
            _studentParsers = studentParsers;
        }

        /// <summary>
        /// Async method takes no parameters and returns serialized entities as file
        /// </summary>
        [HttpGet()]
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

            if (fileExtension == ".xlsx" || fileExtension == ".xls")
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
                throw new Exception("wrong file extension");
            }
        }

        /// <summary>
        /// Parse student's file from xml
        /// </summary>
        public async Task XmlImportAsync(IFormFile formFile)
        {
            await _studentParsers.XmlParseAsync(formFile);
        }

        /// <summary>
        /// Parse student's file from csv
        /// </summary>
        public async Task CsvImportAsync(IFormFile formFile)
        {
            await _studentParsers.CsvParseAsync(formFile);
        }

        /// <summary>
        /// Parse student's file from excel
        /// </summary>
        public async Task ExcelImportAsync(IFormFile formFile)
        {
            await _studentParsers.ExcelParseAsync(formFile);
        }
    }
}
