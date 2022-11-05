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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public XmlParser(IPoliceRepository policeRepository,
                         IWebHostEnvironment webHostEnvironment)
        {
            _policeRepository = policeRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        /// <summary>
        /// Parse XML file and save to database
        /// </summary>
        public async Task ReadXMLAsync(IFormFile file)
        {
            List<IPolice> polices = new List<IPolice>();

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            foreach (XmlNode node in xmlDocument.SelectNodes("/dataset/record"))
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occured with a message: " + ex.Message.ToString());
                }
            }
            await _policeRepository.AddRangeAsync(polices.ToArray());

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
