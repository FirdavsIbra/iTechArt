using CsvHelper;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces.IPoliceParsers;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.Constants;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Globalization;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class PoliceService : IPoliceService
    {
        private readonly IPoliceRepository _policeRepository;
        private readonly IExcelParser _excelParser;
        private readonly ICsvParser _csvParser;
        private readonly IXmlParser _xmlParser;

        public PoliceService(IPoliceRepository policeRepository,
                             IExcelParser excelParser,
                             ICsvParser csvParser,
                             IXmlParser xmlParser)
        {
            _policeRepository = policeRepository;
            _excelParser = excelParser;
            _csvParser = csvParser;
            _xmlParser = xmlParser;
        }

        /// <summary>
        /// Export data from the databse
        /// </summary>
        public async Task<IPolice[]> GetAllPolice()
        {
            return await _policeRepository.GetAllAsync();
        }

        /// <summary>
        /// Import XLSX or XLS data to the database
        /// </summary>
        public async Task ImportExcel(IFormFile formFile)
        {
            await _excelParser.ReadExcelAsync(formFile);
        }


        /// <summary>
        /// Import XML data to the database
        /// </summary>
        public async Task ImportXml(IFormFile formFile)
        {
            await _xmlParser.ReadXMLAsync(formFile);
        }


        /// <summary>
        /// Import CSV data to the database
        /// </summary>
        public async Task ImportCsv(IFormFile formFile)
        {
            await _csvParser.ReadCSVAsync(formFile);
        }

        /// <summary>
        /// Add or Update Police entity to/from database
        /// </summary>
        public async Task AddPolice(IPolice police)
        {
            await _policeRepository.AddAsync(police);
        }





        ////////////////////////////////////////////////////////////////////////
        /// OLD API FUNCTIONS
        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Import data to the database
        /// </summary>
        [Obsolete]
        public async Task ImportPoliceData(IFormFile formFile)
        {
            string fileExtension = Path.GetExtension(formFile.FileName);

            // .xlsx type
            if (fileExtension == FileConstants.xlsxExt || FileConstants.EXCEL.Contains(formFile.ContentType))
            {
                await ReadExcelAsync(formFile);
            }
            // .csv type
            else if (fileExtension == FileConstants.csvExt || FileConstants.CSV.Contains(formFile.ContentType))
            {
                await ReadCSVAsync(formFile);
            }
            // .xml type
            else if (fileExtension == FileConstants.xmlExt || FileConstants.XML.Contains(formFile.ContentType))
            {
                await ReadXMLAsync(formFile);
            }
        }


        /// <summary>
        /// Parse XML file and save to database
        /// </summary>
        [Obsolete]
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

        /// <summary>
        /// Parse CSV file and save to database
        /// </summary>
        [Obsolete]
        public async Task ReadCSVAsync(IFormFile file)
        {
            using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;
                using (var sr = new StreamReader(fileStream))
                {
                    using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<PoliceMap>();
                        var records = csv.GetRecords<PoliceDto>().ToArray();
                        await _policeRepository.AddRangeAsync(records);
                    }
                }
            }
        }

        /// <summary>
        /// Parse XLSX file and save to database
        /// </summary>
        [Obsolete]
        public async Task ReadExcelAsync(IFormFile file)
        {
            var polices = new List<IPolice>();

            using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                using (var package = new ExcelPackage(fileStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var policeDto = new PoliceDto
                        {
                            Name = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            Surname = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            Email = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            Gender = Enum.Parse<Gender>(worksheet.Cells[row, 4].Value.ToString()),
                            Address = worksheet.Cells[row, 5].Value.ToString().Trim(),
                            JobTitle = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            Salary = Convert.ToDouble(worksheet.Cells[row, 7].Value)
                        };
                        polices.Add(policeDto);
                    }
                    await _policeRepository.AddRangeAsync(polices.ToArray());
                }
            }
        }
    }
}