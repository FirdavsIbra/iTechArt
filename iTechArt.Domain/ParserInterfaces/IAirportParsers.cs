using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IAirportParsers
    {
        public Task CsvParser(IFormFile file);
        public Task ExcelParser(IFormFile file);
        public Task XmlParser(IFormFile file);
    }
}
