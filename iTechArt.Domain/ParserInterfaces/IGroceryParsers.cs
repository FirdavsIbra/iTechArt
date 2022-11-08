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
        public Task<ITaskResult> RecordCsvToDatabase(IFormFile formFile);

        public Task<ITaskResult> RecordExcelToDatabase(IFormFile formFile);

        public Task<ITaskResult> RecordXmlToDatabase(IFormFile formFile);
    }
}
