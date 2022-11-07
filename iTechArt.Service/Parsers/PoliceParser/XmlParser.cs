using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Xml;

namespace iTechArt.Service.Parsers.PoliceParser
{
    public class XmlParser : IXmlParser
    {
        private readonly IPoliceRepository _policeRepository;

        public XmlParser(IPoliceRepository policeRepository)
        {
            _policeRepository = policeRepository;
        }


        /// <summary>
        /// Parse XML file and save to database
        /// </summary>
        public async Task ReadXMLAsync(IFormFile file)
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
                        Gender = (Gender)Convert.ToByte(node["Gender"].InnerText),
                        Address = node["Address"].InnerText,
                        JobTitle = node["JobTitle"].InnerText,
                        Salary = Convert.ToDouble(node["Salary"].InnerText)
                    };
                    polices.Add(policeDto);
                }
                await _policeRepository.AddRangeAsync(polices.ToArray());
            }
        }
    }
}
