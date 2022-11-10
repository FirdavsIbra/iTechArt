using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Service.Services
{
    public sealed class PupilService : IPupilService
    {
        private readonly IPupilRepository _pupilRepository;
        private readonly IPupilParser _pupilParsers;
        public PupilService(IPupilRepository pupilRepository, IPupilParser pupilParsers)
        {
            _pupilRepository = pupilRepository;
            _pupilParsers = pupilParsers;
        }

        /// <summary>
        /// Get all pupils.
        /// </summary>
        public async Task<IPupil[]> GetAllAsync()
        {
            return await _pupilRepository.GetAllAsync();
        }

        /// <summary>
        /// Import pupil's file.
        /// </summary>
        public async Task ImportPupilsFileAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xlsx" || fileExtension == ".xls")
            {
                await ImportExcelAsync(file);
            }
            else if (fileExtension == ".csv")
            {
                await ImportCsvAsync(file);
            }
            else if (fileExtension == ".xml")
            {
                await ImportXmlAsync(file);
            }
        }

        /// <summary>
        /// Parse pupil's file from excel.
        /// </summary>
        public async Task ImportExcelAsync(IFormFile file)
        {
            var pupilsFromExcel = await _pupilParsers.ExcelParseAsync(file);

            await _pupilRepository.AddRangeAsync(pupilsFromExcel);
        }

        /// <summary>
        /// Parse pupil's file from csv.
        /// </summary>
        public async Task ImportCsvAsync(IFormFile file)
        {
            var pupilsFromCsv = await _pupilParsers.CsvParseAsync(file);

            await _pupilRepository.AddRangeAsync(pupilsFromCsv);
        }

        /// <summary>
        /// Parse pupil's file from xml.
        /// </summary>
        public async Task ImportXmlAsync(IFormFile file)
        {
            var pupilsFromXml = await _pupilParsers.XmlParseAsync(file);
         
            await _pupilRepository.AddRangeAsync(pupilsFromXml);
        }
    }
}
