using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface ICsvParser
    {
        /// <summary>
        /// Reads CSV file and parses it
        /// </summary>
        public Task ReadCSVAsync(IFormFile file);
    }
}
