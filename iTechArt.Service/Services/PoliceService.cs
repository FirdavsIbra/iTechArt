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
        /// <returns> List of police officers from database </returns>    
        public async Task<List<IPolice>> ExportPoliceData()
        {
            return await _policeRepository.GetAllAsync();
        }

        /// <summary>
        /// Import data to the database
        /// </summary>
        /// <returns> Empty List of string </returns>
        public async Task<List<string>> ImportPoliceData()
        {
            return new List<string>();
        }
    }
}
