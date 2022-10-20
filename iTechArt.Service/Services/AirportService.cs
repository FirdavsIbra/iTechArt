using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public sealed class AirportService : IAirportsService
    {
        /// <summary>
        /// Exporting airport datas
        /// </summary>
        public async Task<List<string>> ExportAirportExcel()
        {
            return new List<string>();
        }
        /// <summary>
        /// Importing airport datas
        /// </summary>
        public async Task<List<string>> ImportAirportExcel()
        {
            return new List<string>();
        }
    }
}
