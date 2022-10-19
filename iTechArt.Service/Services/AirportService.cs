using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public class AirportService : IAirportsService
    {
        public async Task<List<string>> ExportAirportExcel()
        {
            return new List<string>();
        }

        public async Task<List<string>> ImportAirportExcel()
        {
            return new List<string>();
        }
    }
}
