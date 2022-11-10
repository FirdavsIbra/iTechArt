using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IPupilParser
    {
        /// <summary>
        /// Parse pupil's file from excel.
        /// </summary>
        public Task<IPupil[]> ExcelParseAsync(IFormFile file);

        /// <summary>
        /// Parse pupil's file from csv.
        /// </summary>
        public Task<IPupil[]> CsvParseAsync(IFormFile file);

        /// <summary>
        /// Parse pupil's file from xml.
        /// </summary>
        public Task<IPupil[]> XmlParseAsync(IFormFile file);
    }
}
