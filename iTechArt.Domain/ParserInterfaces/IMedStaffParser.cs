using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IMedStaffParser
    {
        /// <summary>
        /// Parse excel file file 
        /// </summary>
        Task ParseExcelAsync(IFormFile file);

        /// <summary>
        /// Parse CSV file
        /// </summary>
        Task ParseCSVAsync(IFormFile file);

        /// <summary>
        /// Parse XML file
        /// </summary>
        Task ParseXMLAsync(IFormFile file);
    }
}
