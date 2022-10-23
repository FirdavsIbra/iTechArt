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
        public IPolice[] ExportPoliceData()
        {
            return _policeRepository.GetAll();
        }

        /// <summary>
        /// Import data to the database
        /// </summary>
        public IPolice[] ImportPoliceData()
        {
            return _policeRepository.GetAll();
        }
    }
}
