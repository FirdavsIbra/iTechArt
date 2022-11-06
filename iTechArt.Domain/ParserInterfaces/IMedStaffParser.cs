using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IMedStaffParser
    {
        /// <summary>
        /// Parse excel file file 
        /// </summary>
        Task ParseExcel(IFormFile file);

        /// <summary>
        /// Parse CSV file
        /// </summary>
        Task ParseCSV(IFormFile file);

        /// <summary>
        /// Parse XML file
        /// </summary>
        Task ParseXML(IFormFile file);
    }
}
