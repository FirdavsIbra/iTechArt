using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IGroceryService
    {
        /// <summary>
        /// Import data for grocery
        /// </summary>
        public IGrocery[] ImportGrocery();

        /// <summary>
        /// Export data for grocery
        /// </summary>
        public IGrocery[] ExportGrocery();

        /// <summary>
        /// Count of grocery not implemented yet
        /// </summary>
        public int GetCountOfGrocery();

        /// <summary>
        /// taking items from Xlsx file and record to db
        /// </summary>
        public Task<IServiceResult> RecordXlsxToDatabase(IFormFile formFile);
        /// <summary>
        /// taking items from csv file and record to db
        /// </summary>
        public Task<IServiceResult> RecordCsvToDatabase(IFormFile formFile);
        /// <summary>
        /// taking items from xml file and record to db
        /// </summary>
        public Task<IServiceResult> RecordXmlToDatabase(IFormFile formFile);
    }
}
