using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPoliceService
    {
        /// <summary>
        /// function to import XLSX or XLS data to the database.
        /// </summary>
        public Task ImportExcel(IFormFile formFile);


        /// <summary>
        /// function to import XML data to the database.
        /// </summary>
        public Task ImportXml(IFormFile formFile);

        /// <summary>
        /// function to import CSV data to the database.
        /// </summary>
        public Task ImportCsv(IFormFile formFile);

        /// <summary>
        /// function to export data from the database.
        /// </summary>
        public Task<IPolice[]> GetAllPolice();
    }
}
