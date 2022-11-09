using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.IPoliceParsers
{
    public interface IXmlParse
    {
        /// <summary>
        /// Parses XML file and returns array of entities.
        /// </summary>
        public Task<IPolice[]> ParseXMLAsync(IFormFile file);
    }
}
