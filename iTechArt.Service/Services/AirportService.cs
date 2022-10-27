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
        private readonly string[] fileExtensions = { ".xlsx", ".xls", ".csv", ".xml", "application/vnd.ms-excel", "officedocument.spreadsheetml.sheet"  };

        public AirportService(IAirportRepository airportRepository, IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Exporting airport datas
        /// </summary>
        public IAirport[] ExportAirportExcel()
        {
            return _airportRepository.GetAll();
        }
        /// <summary>
        /// Importing airport datas
        /// </summary>
        public async Task ImportAirportExcel(IFormFile file)
        {
            try
            {
                var fileExtension = Path.GetExtension(file.FileName);

                if (fileExtensions.Contains(fileExtension))
                {
                    using (var stream = new MemoryStream())
                    {
                        file.CopyTo(stream);
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
                               
                                IAirport airport = _mapper.Map<IAirport>(list);
                                await _airportRepository.AddAsync(airport);
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
    }
}
