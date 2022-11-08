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

        /// <summary>
        /// Parse student's file from xml
        /// </summary>
        public Task XmlImportAsync(IFormFile formFile);

        /// <summary>
        /// Parse student's file from csv
        /// </summary>
        public Task CsvImportAsync(IFormFile formFile);

        /// <summary>
        /// Parse student's file from excel
        /// </summary>
        public Task ExcelImportAsync(IFormFile formFile);

    }
}
