using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IAirportsService
    {
        /// <summary>
        /// Interface of Importing airport datas
        /// </summary>
        public Task ImportAirportExcel(IFormFile file);

        /// <summary>
        /// Interface of Exporting airport datas
        /// </summary>
        public IAirport[] ExportAirportExcel();
    }
}
