using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Repository.BusinessModels.HelperModels;
using iTechArt.Repository.Mappers;
using iTechArt.Service.DTOs;
using iTechArt.Service.Parsers;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Xml.Linq;

namespace iTechArt.Serivce.Services
{
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository _groceryRepository;
        private readonly IGroceryParsers _groceryParsers;
        public GroceryService(IGroceryRepository groceryRepository, IGroceryParsers groceryParsers)
        {
            _groceryParsers = groceryParsers;
            _groceryRepository = groceryRepository;
        }

        /// <summary>
        /// Export grocery data
        /// </summary>
        public Task<IGrocery[]> ExportGrocery()
        {
            return _groceryRepository.GetAllAsync();
        }

        /// <summary>
        /// Get Count of Groceries
        /// </summary>
        public async ValueTask<int> GetCountOfGrocery()
        {
            return await _groceryRepository.GetCountOfGrocery();
        }
        /// <summary>
        /// Import Csv format grocery files
        /// </summary>
        public async Task ImportCSVGrocery(IFormFile formFile)
        {
            await _groceryParsers.RecordCsvToDatabase(formFile);
        }
        /// <summary>
        /// Import Excel format grocery files
        /// </summary>
        public async Task ImportExcelGrocery(IFormFile formFile)
        {
            await _groceryParsers.RecordExcelToDatabase(formFile);
        }
        /// <summary>
        /// Import XML format grocery files
        /// </summary>
        public async Task ImportXMLGrocery(IFormFile formFile)
        {
            await _groceryParsers.RecordXmlToDatabase(formFile);
        }
    }
}
