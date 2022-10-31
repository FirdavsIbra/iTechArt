using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.Constants;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class AirportService : IAirportsService
    {
        private readonly IAirportRepository _airportRepository;

        public AirportService(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        /// <summary>
        /// Exporting airport datas
        /// </summary>
        public Task<IAirport[]> ExportAirportExcel()
        {
            return _airportRepository.GetAll();
        }

        /// <summary>
        /// Import airport's file
        /// </summary>
        public async Task ImportAirportFile(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (FileConstants.excelExtensions.Contains(fileExtension))
            {
                await AirportExcelParser(file);
            }
            else if (FileConstants.csvExtensions.Contains(fileExtension))
            {
                await AirportCSVParser(file);
            }
            else if (FileConstants.xmlExtensions.Contains(fileExtension))
            {
                await AirportXMLParser(file);
            }
            else
            {
                throw new ArgumentException("Invalid file format");
            }
        }

        /// <summary>
        /// Importing airport datas from excel file
        /// </summary>
        private async Task AirportExcelParser(IFormFile file)
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

                            for (int row = 2; row <= rowCount; row++)
                            {
                                var list = new AirportDTO
                                {
                                    AirportName = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                    BuiltDate = Convert.ToDateTime(worksheet.Cells[row, 2].Value),
                                    Capacity = Convert.ToUInt16(worksheet.Cells[row, 3].Value),
                                    Address = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                    City = worksheet.Cells[row, 5].Value.ToString().Trim(),
                                    EmpoyeesCount = Convert.ToUInt16(worksheet.Cells[row, 6].Value),
                                    PassengersPerYear = Convert.ToInt64(worksheet.Cells[row, 7].Value),
                                    FlightsPerYear = Convert.ToUInt32(worksheet.Cells[row, 8].Value),
                                    AverageTicketPrice = Convert.ToUInt16(worksheet.Cells[row, 9].Value)
                                };

                                await _airportRepository.AddAsync(list);
                            }
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
                throw new ArgumentException(nameof(e));
            }
        }

        /// <summary>
        /// Importing airport datas from csv file
        /// </summary>
        private async Task AirportCSVParser(IFormFile file)
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

                    for (int i = 1; i < csvLines.Length; i++)
                    {
                        var rowData = csvLines[i].Split(',');

                        var list = new AirportDTO
                        {
                            AirportName = rowData[0].ToString().Trim(),
                            BuiltDate = Convert.ToDateTime(rowData[1]),
                            Capacity = Convert.ToUInt16(rowData[2]),
                            Address = rowData[3].ToString().Trim(),
                            City = rowData[4].ToString().Trim(),
                            EmpoyeesCount = Convert.ToUInt16(rowData[5]),
                            PassengersPerYear = Convert.ToInt64(rowData[6]),
                            FlightsPerYear = Convert.ToUInt32(rowData[7]),
                            AverageTicketPrice = Convert.ToUInt16(rowData[8])
                        };

                        await _airportRepository.AddAsync(list);
                    }


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

        /// <summary>
        /// Importing airport datas from xml file
        /// </summary>
        private async Task AirportXMLParser(IFormFile file)
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

                    foreach (XmlNode node in xmlDocument.SelectNodes("/dataset/record"))
                    {
                        var airport = new AirportDTO
                        {
                            AirportName = node["AirportName"].InnerText,
                            BuiltDate = Convert.ToDateTime(node["BuiltDate"].InnerText),
                            Capacity = Convert.ToUInt16(node["Capacity"].InnerText),
                            Address = node["Address"].InnerText,
                            City = node["City"].InnerText,
                            EmpoyeesCount = Convert.ToUInt16(node["EmployeesCount"].InnerText),
                            PassengersPerYear = Convert.ToInt64(node["PassengersPerYear"].InnerText),
                            FlightsPerYear = Convert.ToUInt32(node["FlightsPerYear"].InnerText),
                            AverageTicketPrice = Convert.ToUInt16(node["AverageTicketPrice"].InnerText),
                        };

                        await _airportRepository.AddAsync(airport);
                    }

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
