using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPoliceService
    {
        /// <summary>
        /// function to import data to the database
        /// </summary>
        /// <param name="formFile"></param>
        public Task ImportPoliceData(IFormFile formFile);

        /// <summary>
        /// function to export data from the database
        /// </summary>
        public Task<IPolice[]> ExportPoliceData();

        /// <summary>
        /// Parse and saves XLSX file into database
        /// </summary>
        public Task ReadExcelAsync(IFormFile file);

        /// <summary>
        /// Parse and saves XML file into database
        /// </summary>
        public Task ReadXMLAsync(IFormFile file);

        /// <summary>
        /// Parse and saves CSV file into database
        /// </summary>
        public Task ReadCSVAsync(IFormFile file);
    }
}
