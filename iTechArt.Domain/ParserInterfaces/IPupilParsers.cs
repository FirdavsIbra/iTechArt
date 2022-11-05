using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IPupilParsers
    {
        public Task ExcelParser(IFormFile file);
        public Task CsvParser(IFormFile file);
        public Task XmlParser(IFormFile file);
    }
}
