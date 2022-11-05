using CsvHelper;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
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
        public async Task<IPolice[]> ExportPoliceData()
        {
            return await _policeRepository.GetAllAsync();
        }

        /// <summary>
        /// Import XLSX data to the database
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

        /// <summary>
        /// Get all Police entities from database
        /// </summary>
        public async Task<IPolice[]> GetAllPolice()
        {
            return await _policeRepository.GetAllAsync();
        }

        /// <summary>
        /// Delete Police entity from database
        /// </summary>
        public async Task DeletePolice(long id)
        {
            await _policeRepository.DeleteAsync(id);
        }
    }
}