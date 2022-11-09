using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.Repositories;
using iTechArt.Service.Constants;
using iTechArt.Service.DTOs;
using iTechArt.Service.Helpers;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Globalization;
using System.Xml;

namespace iTechArt.Service.Parsers
{
    public sealed class AirportParser : IAirportParsers
    {
        private readonly IAirportRepository _airportRepository;
        public AirportParser(IAirportRepository airportRepository)
        {
            _airportRepository= airportRepository;
        }

        /// <summary>
        /// csv airport parser
        /// </summary>
        public async Task CsvParserAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".csv")
            {
                using var fileStream = new MemoryStream();

                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;
                using (TextReader csvReader = new StreamReader(fileStream))
                {
                    using (var csv = new CsvReader(csvReader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<AirportMap>();
                        var records = csv.GetRecords<AirportDTO>().ToArray();

                        await _airportRepository.AddRangeAsync(records);
                    }
                }
            }
        }   
        public async Task ExcelParser(IFormFile file)
        {
              var fileExtension = Path.GetExtension(file.FileName);

                if (FileConstants.excelExtensions.Contains(fileExtension))
                {
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        using (var package = new ExcelPackage(stream))
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                            var rowCount = worksheet.Dimension.Rows;

                            IList<AirportDTO> airports = new List<AirportDTO>(rowCount - 2);

                            for (int row = 2; row <= rowCount; row++)
                            {
                                var airport = new AirportDTO
                                {
                                    AirportName = worksheet.Cells[row,AirportIndexConstants.AIRPORTNAMEINDEX].Value.ToString().Trim(),
                                    BuiltDate = DateOnly.Parse(worksheet.Cells[row, AirportIndexConstants.BUILDDATEINDEX].Value.ToString()),
                                    Capacity = Convert.ToUInt16(worksheet.Cells[row, AirportIndexConstants.CAPACITYINDEX].Value),
                                    Address = worksheet.Cells[row, AirportIndexConstants.ADDRESSINDEX].Value.ToString().Trim(),
                                    City = worksheet.Cells[row, AirportIndexConstants.CITYINDEX].Value.ToString().Trim(),
                                    EmployeesCount = Convert.ToUInt16(worksheet.Cells[row, AirportIndexConstants.EMPLOYEESCOUNTINDEX].Value),
                                    PassengersPerYear = Convert.ToInt64(worksheet.Cells[row, AirportIndexConstants.PASSANGERPERYEARINDEX].Value),
                                    FlightsPerYear = Convert.ToUInt32(worksheet.Cells[row, AirportIndexConstants.FLIGHTSPERYEARINDEX].Value),
                                    AverageTicketPrice = Convert.ToUInt16(worksheet.Cells[row, AirportIndexConstants.AVERAGETICKETPRICEINDEX].Value)
                                };

                                airports.Add(airport);
                            }
                            await _airportRepository.AddRangeAsync(airports);
                        }
                    }
                }
                else
                {
                    throw new Exception("Upload correct File!!!");
                }
        }

        public async Task XmlParser(IFormFile file)
        {
             var fileExtension = Path.GetExtension(file.FileName);

             if (FileConstants.xmlExtensions.Contains(fileExtension))
             {
                using var fileStream = new MemoryStream();
                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileStream);

                var nodes = xmlDocument.SelectNodes("/airports/airport");

                    IList<AirportDTO> airports = new List<AirportDTO>(nodes.Count);

                    for (int node = 0; node < nodes.Count; node++)
                    {
                        AirportDTO airport = new AirportDTO
                        {
                            AirportName = nodes[node]["AirportName"].InnerText,
                            BuiltDate = DateOnly.Parse(nodes[node]["BuiltDate"].InnerText),
                            Capacity = Convert.ToUInt16(nodes[node]["Capacity"].InnerText),
                            Address = nodes[node]["Address"].InnerText,
                            City = nodes[node]["City"].InnerText,
                            EmployeesCount = Convert.ToUInt16(nodes[node]["EmployeesCount"].InnerText),
                            PassengersPerYear = Convert.ToInt64(nodes[node]["PassengersPerYear"].InnerText),
                            FlightsPerYear = Convert.ToUInt32(nodes[node]["FlightsPerYear"].InnerText),
                            AverageTicketPrice = Convert.ToUInt16(nodes[node]["AverageTicketPrice"].InnerText),
                        };
                        airports.Add(airport);
                    }
                    await _airportRepository.AddRangeAsync(airports);
                }
                else
                {
                    throw new ArgumentException("Invalid file format");
                }
            }         
    }

    internal class AirportMap : ClassMap<AirportDTO>
    {
        public AirportMap()
        {
            var tmpConverter = new DateOnlyHelper();

            Map(a => a.AirportName).Name("Airportname");
            Map(a => a.BuiltDate).Name("BuiltDate");
            Map(a => a.Capacity).Name("Capacity");
            Map(a => a.Address).Name("Address");
            Map(a => a.City).Name("City");
            Map(a => a.EmployeesCount).Name("EmployeesCount");
            Map(a => a.PassengersPerYear).Name("PassengersPerYear");
            Map(a => a.FlightsPerYear).Name("FlightsPerYear");
            Map(a => a.AverageTicketPrice).Name("AverageTicketPrice");
        }
    }
}
