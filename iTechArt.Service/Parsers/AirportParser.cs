using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Service.Constants;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
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
        public async Task CsvParser(IFormFile file)
        {
            try
            {
                var fileExtension = Path.GetExtension(file.FileName);

                if (FileConstants.csvExtensions.Contains(fileExtension))
                {
                    var fileName = DateTime.Now.Ticks + ".csv"; //Create a new Name for the file due to security reasons.
                    var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                    if (!Directory.Exists(pathBuilt))
                    {
                        Directory.CreateDirectory(pathBuilt);
                    }

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var csvLines = File.ReadAllLines(path);

                    IList<IAirport> airports = new List<IAirport>(csvLines.Length - 1);

                    for (int i = 1; i < csvLines.Length; i++)
                    {
                        var rowData = csvLines[i].Split(',');

                        var airport = new AirportDTO
                        {
                            AirportName = rowData[0].ToString().Trim(),
                            BuiltDate = Convert.ToDateTime(rowData[1]),
                            Capacity = Convert.ToUInt16(rowData[2]),
                            Address = rowData[3].ToString().Trim(),
                            City = rowData[4].ToString().Trim(),
                            EmployeesCount = Convert.ToUInt16(rowData[5]),
                            PassengersPerYear = Convert.ToInt64(rowData[6]),
                            FlightsPerYear = Convert.ToUInt32(rowData[7]),
                            AverageTicketPrice = Convert.ToUInt16(rowData[8])
                        };
                        airports.Add(airport);
                    }
                    await _airportRepository.AddRangeAsync(airports);


                    //Deleting after having used the created path
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                else
                {
                    throw new Exception("Upload correct File!!!");
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(nameof(e));
            }
        }

        public async Task ExcelParser(IFormFile file)
        {
           try
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

                            IList<IAirport> airports = new List<IAirport>(rowCount - 2);

                            for (int row = 2; row <= rowCount; row++)
                            {
                                var airport = new AirportDTO
                                {
                                    AirportName = worksheet.Cells[row,AirportIndexConstants.AIRPORTNAMEINDEX].Value.ToString().Trim(),
                                    BuiltDate = Convert.ToDateTime(worksheet.Cells[row, AirportIndexConstants.BUILDDATEINDEX].Value),
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
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task XmlParser(IFormFile file)
        {
            try
            {
                var fileExtension = Path.GetExtension(file.FileName);

                if (FileConstants.xmlExtensions.Contains(fileExtension))
                {
                    var fileName = DateTime.Now.Ticks + ".xml"; //Create a new Name for the file due to security reasons.
                    var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                    if (!Directory.Exists(pathBuilt))
                    {
                        Directory.CreateDirectory(pathBuilt);
                    }

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", file.FileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(path);

                    IList<IAirport> airports = new List<IAirport>(xmlDocument.SelectNodes("/airports/airport").Count);

                    foreach (XmlNode node in xmlDocument.SelectNodes("/airports/airport"))
                    {
                        var airport = new AirportDTO
                        {
                            AirportName = node["AirportName"].InnerText,
                            BuiltDate = Convert.ToDateTime(node["BuiltDate"].InnerText),
                            Capacity = Convert.ToUInt16(node["Capacity"].InnerText),
                            Address = node["Address"].InnerText,
                            City = node["City"].InnerText,
                            EmployeesCount = Convert.ToUInt16(node["EmployeesCount"].InnerText),
                            PassengersPerYear = Convert.ToInt64(node["PassengersPerYear"].InnerText),
                            FlightsPerYear = Convert.ToUInt32(node["FlightsPerYear"].InnerText),
                            AverageTicketPrice = Convert.ToUInt16(node["AverageTicketPrice"].InnerText),
                        };
                        airports.Add(airport);
                    }
                    await _airportRepository.AddRangeAsync(airports);

                    //Deleting after having used the created path
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid file format");
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(nameof(e));
            }
        }
    }
}
