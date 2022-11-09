using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.IPoliceParsers
{
    public interface IExcelParse
    {
        /// <summary>
        /// Parses XLSX file and return array of entities.
        /// </summary>
        public Task<IPolice[]> ParseExcelAsync(IFormFile file);
    }
}
