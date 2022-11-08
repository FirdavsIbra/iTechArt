using iTechArt.Database.Entities.Airports;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Repository.Repositories;
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

        private readonly IAirportParsers _airportParsers;
        public AirportService(IAirportRepository airportRepository, IAirportParsers airportParsers)
        {
            _airportRepository = airportRepository;
            _airportParsers = airportParsers;
        }
        
        /// <summary>
        /// Exporting airport datas
        /// </summary>
        public async Task<IAirport[]> ExportAirportExcel()
        {
            return await _airportRepository.GetAllAsync();
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
        public async Task AirportExcelParser(IFormFile file)
        {
            await _airportParsers.ExcelParser(file);
        }

        /// <summary>
        /// Importing airport datas from csv file
        /// </summary>
        public async Task AirportCSVParser(IFormFile file)
        {
            await _airportParsers.CsvParser(file);
        }

        /// <summary>
        /// Importing airport datas from xml file
        /// </summary>
        public async Task AirportXMLParser(IFormFile file)
        {
            await _airportParsers.XmlParser(file);
        }   
    }
}
