using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Dtos;
using ITechArt.Parsers.IPoliceParsers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ITechArt.Parsers.PoliceParsers
{
    public class ParseXml : IXmlParse
    {
        /// <summary>
        /// Parse XML file and returns array of entities.
        /// </summary>
        public async Task<IPolice[]> ParseXMLAsync(IFormFile file)
        {
            List<IPolice> polices = new List<IPolice>();
            using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileStream);

                foreach (XmlNode node in xmlDocument.SelectNodes("/dataset/record"))
                {
                    PoliceDto policeDto = new PoliceDto
                    {
                        Name = node["Name"].InnerText,
                        Surname = node["Surname"].InnerText,
                        Email = node["Email"].InnerText,
                        Gender = Enum.Parse<Gender>(node["Gender"].InnerText),
                        Address = node["Address"].InnerText,
                        JobTitle = node["JobTitle"].InnerText,
                        Salary = Convert.ToDouble(node["Salary"].InnerText)
                    };
                    polices.Add(policeDto);
                }
                return polices.ToArray();
            }
        }
    }
}
