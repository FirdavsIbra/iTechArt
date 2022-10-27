using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

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
        public async Task<IPolice[]> ImportPoliceData()
        {
            return await _policeRepository.GetAllAsync();
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


        /// <summary>
        /// Function contains all file reading related logic
        /// </summary>
        public async Task ImportPoliceFile()
        {
            
        }
    }
}
