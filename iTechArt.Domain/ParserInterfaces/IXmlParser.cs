using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IXmlParser
    {
        /// <summary>
        /// Reads XML file and parses it
        /// </summary>
        public Task ReadXMLAsync(IFormFile file);
    }
}
