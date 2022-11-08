using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IPupilParsers
    {
        /// <summary>
        /// Parse pupil's file from excel
        /// </summary>
        public Task ExcelParseAsync(IFormFile file);

        /// <summary>
        /// Parse pupil's file from csv
        /// </summary>
        public Task CsvParseAsync(IFormFile file);

        /// <summary>
        /// Parse pupil's file from xml
        /// </summary>
        public Task XmlParseAsync(IFormFile file);
    }
}
