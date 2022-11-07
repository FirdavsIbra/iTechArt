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
        private readonly IPupilParsers _pupilParsers;
        public PupilService(IPupilRepository pupilRepository, IPupilParsers pupilParsers)
        {
            _pupilRepository = pupilRepository;
            _pupilParsers = pupilParsers;
        }

        /// <summary>
        /// Get all pupils
        /// </summary>
        public async Task<IPupil[]> GetAllAsync()
        {
            return await _pupilRepository.GetAllAsync();
        }

        /// <summary>
        /// Import pupil's file
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
        /// Get pupil by id
        /// </summary>
        public async Task<IPupil> GetByIdAsync(long id) 
        { 
            return await _pupilRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Add pupil to database
        /// </summary>
        public async Task AddAsync(IPupil pupil)
        {
            await _pupilRepository.AddAsync(pupil);
        }

        /// <summary>
        /// Delete pupil
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            await _pupilRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Parse pupil's file from excel
        /// </summary>
        public async Task ImportExcelAsync(IFormFile file)
        {
            await _pupilParsers.ExcelParser(file);
        }

        /// <summary>
        /// Parse pupil's file from csv
        /// </summary>
        public async Task ImportCsvAsync(IFormFile file)
        {
            await _pupilParsers.CsvParser(file);
        }

        /// <summary>
        /// Parse pupil's file from xml
        /// </summary>
        public async Task ImportXmlAsync(IFormFile file)
        {
            await _pupilParsers.XmlParser(file);
        }
    }
}
