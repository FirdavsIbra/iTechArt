using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPoliceService
    {
        /// <summary>
        /// function to import XLSX data to the database
        /// </summary>
        public Task ImportExcel(IFormFile formFile);

        /// <summary>
        /// function to import XML data to the database
        /// </summary>
        public Task ImportXml(IFormFile formFile);

        /// <summary>
        /// function to import CSV data to the database
        /// </summary>
        public Task ImportCsv(IFormFile formFile);

        /// <summary>
        /// function to export data from the database
        /// </summary>
        public Task<IPolice[]> ExportPoliceData();

        // <summary>
        /// Add or Update Police entity to/from database
        /// </summary>
        public Task AddPolice(IPolice police);

        /// <summary>
        /// Get all Police entities from database
        /// </summary>
        public Task<IPolice[]> GetAllPolice();

        /// <summary>
        /// Delete Police entity from database
        /// </summary>
        public Task DeletePolice(long id);
    }
}
