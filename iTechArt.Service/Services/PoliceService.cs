using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.Constants;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Service.Services
{
    public sealed class PoliceService : IPoliceService
    {
        private readonly IPoliceRepository _policeRepository;

        public PoliceService(IPoliceRepository policeRepository)
        {
            _policeRepository = policeRepository;
        }

        /// <summary>
        /// Export data from the databse
        /// </summary>
        public async Task<IPolice[]> ExportPoliceData()
        {
            return await _policeRepository.GetAllAsync();
        }

        /// <summary>
        /// Import data to the database
        /// </summary>
        public async Task ImportPoliceData(IFormFile formFile)
        {
            string fileExtension = Path.GetExtension(formFile.FileName);
            
            // .xlsx type
            if (fileExtension == FileConstants.Extensions[0] || FileConstants.EXCEL.Contains(formFile.ContentType))
            {
                await _policeRepository.ReadExcelAsync(formFile);
            }
            // .csv type
            else if(fileExtension == FileConstants.Extensions[2] || FileConstants.CSV.Contains(formFile.ContentType))
            {
                await _policeRepository.ReadCSVAsync(formFile);
            }
            // .xml type
            else if(fileExtension == FileConstants.Extensions[3] || FileConstants.XML.Contains(formFile.ContentType))
            {
                await _policeRepository.ReadXMLAsync(formFile);
            }
        }


        /// <summary>
        /// Add or Update Police entity to/from database
        /// </summary>
        public async Task AddUpdatePolice(IPolice police)
        {
            await _policeRepository.AddUpdateAsync(police);
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
