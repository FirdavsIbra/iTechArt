using AutoMapper;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace iTechArt.Service.Services
{
    public sealed class AirportService : IAirportsService
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;
        private readonly string[] excelExtensions = { ".xlsx", ".xls", ".xlsm", ".xlsb", ".xltx", ".xltm", ".xlt", ".xlam", ".xla", ".xlw" };

        public AirportService(IAirportRepository airportRepository, IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Exporting airport datas
        /// </summary>
        public Task<IAirport[]> ExportAirportExcel()
        {
            return _airportRepository.GetAll();
        }
        /// <summary>
        /// Importing airport datas from excel file
        /// </summary>
        public async Task ImportAirportExcel(IFormFile file)
        {
            try
            {
                var fileExtension = Path.GetExtension(file.FileName);

                if (excelExtensions.Contains(fileExtension))
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

        public async Task ImportAirportCSV(IFormFile file)
        {
            try
            {
                if (file.FileName.Contains(".csv"))
                {
                    var fileName = DateTime.Now.Ticks + ".csv"; //Create a new Name for the file due to security reasons.
                    var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                    if (!Directory.Exists(pathBuilt))
                    {
                        Directory.CreateDirectory(pathBuilt);
                    }

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

                    using (var stream = new FileStream(path, FileMode.Open))
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
    }
}
