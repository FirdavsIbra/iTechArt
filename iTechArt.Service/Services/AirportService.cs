using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public sealed class AirportService : IAirportsService
    {
        private readonly IAirportRepository _airportRepository;

        public AirportService(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        /// <summary>
        /// Exporting airport datas
        /// </summary>
        public IAirport[] ExportAirportExcel()
        {
            return _airportRepository.GetAll();
        }
        /// <summary>
        /// Importing airport datas
        /// </summary>
        public IAirport[] ImportAirportExcel()
        {
            return _airportRepository.GetAll();
        }
    }
}
