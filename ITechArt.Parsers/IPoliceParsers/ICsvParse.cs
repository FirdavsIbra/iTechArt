using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.IPoliceParsers
{
    public interface ICsvParse
    {
        /// <summary>
        /// Parses CSV file and returns array of entities.
        /// </summary>
        public Task<IPolice[]> ParseCSVAsync(IFormFile file);
    }
}
