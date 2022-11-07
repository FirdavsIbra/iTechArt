using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IMedStaffService
    {
        /// <summary>
        /// Uploads a file of data 
        /// </summary>
        public Task ImportMedStaffFile(IFormFile file);

        /// <summary>
        /// Uploads excel file of data
        /// </summary>
        public Task ExcelParse(IFormFile file);

        /// <summary>
        /// Uploads xml file of data
        /// </summary>
        public Task XMLParse(IFormFile file);

        /// <summary>
        /// Uploads csv file of data
        /// </summary>
        public Task CSVParse(IFormFile file);

        /// <summary>
        /// Gets all info from database
        /// </summary>
        public Task<IMedStaff[]> ExportMedStaffFile();

    }
}
