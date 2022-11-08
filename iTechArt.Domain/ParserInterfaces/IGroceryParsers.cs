using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IGroceryParsers
    {
        public Task RecordCsvToDatabase(IFormFile formFile);

        public Task RecordExcelToDatabase(IFormFile formFile);

        public Task RecordXmlToDatabase(IFormFile formFile);
    }
}
