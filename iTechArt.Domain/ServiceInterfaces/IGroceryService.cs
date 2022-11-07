using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IGroceryService
    {
        /// <summary>
        /// Import Csv format data for grocery
        /// </summary>
        public Task ImportCSVGrocery(IFormFile formFile);
        /// <summary>
        /// Import Excel format data for grocery
        /// </summary>
        public Task ImportExcelGrocery(IFormFile formFile);
        /// <summary>
        /// Import Xml format data for grocery
        /// </summary>
        public Task ImportXMLGrocery(IFormFile formFile);

        /// <summary>
        /// Export data for grocery
        /// </summary>
        public Task<IGrocery[]> ExportGrocery();

        /// <summary>
        /// Count of grocery not implemented yet
        /// </summary>
        public ValueTask <int> GetCountOfGrocery();

        /// <summary>
        /// taking items from Xlsx file and record to db
        /// </summary>
    }
}
