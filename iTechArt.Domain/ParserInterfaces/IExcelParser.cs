using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IExcelParser
    {
        /// <summary>
        /// Reads XLSX file and parses it
        /// </summary>
        public Task ReadExcelAsync(IFormFile file);
    }
}
