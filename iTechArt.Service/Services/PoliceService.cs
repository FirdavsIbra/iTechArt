using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using ITechArt.Parsers.IPoliceParsers;
using Microsoft.AspNetCore.Http;


namespace iTechArt.Service.Services
{
    public sealed class PoliceService : IPoliceService
    {
        private readonly IPoliceRepository _policeRepository;
        private readonly ICsvParse _csvParse;
        private readonly IExcelParse _excelParse;
        private readonly IXmlParse _xmlParse;


        public PoliceService(IPoliceRepository policeRepository,
                             IXmlParse xmlParse,
                             IExcelParse excelParse,
                             ICsvParse csvParse)
        {
            _policeRepository = policeRepository;
            _xmlParse = xmlParse;
            _excelParse = excelParse;
            _csvParse = csvParse;
        }

        /// <summary>
        /// Get all data from the databse.
        /// </summary>
        public async Task<IPolice[]> GetAllPolice()
        {
            return await _policeRepository.GetAllAsync();
        }

        /// <summary>
        /// Import XLSX or XLS data to the database.
        /// </summary>
        public async Task ImportExcel(IFormFile formFile)
        {
            var policesArr = await _excelParse.ParseExcelAsync(formFile);
            await _policeRepository.AddRangeAsync(policesArr);
        }


        /// <summary>
        /// Import XML data to the database.
        /// </summary>
        public async Task ImportXml(IFormFile formFile)
        {
            var policesArr = await _xmlParse.ParseXMLAsync(formFile);
            await _policeRepository.AddRangeAsync(policesArr);
        }


        /// <summary>
        /// Import CSV data to the database.
        /// </summary>
        public async Task ImportCsv(IFormFile formFile)
        {
            var policesArr = await _csvParse.ParseCSVAsync(formFile);
            await _policeRepository.AddRangeAsync(policesArr);
        }
    }
}