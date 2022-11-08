using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IAirportsService
    {
        /// <summary>
        /// Interface of Importing airport datas
        /// </summary>
        public Task ImportAirportFile(IFormFile file);

        /// <summary>
        /// Parse airport's file from excel
        /// </summary>      
        public Task AirportExcelParser(IFormFile file);

        /// <summary>
        /// Parse airport's file from csv
        /// </summary>
        public Task AirportCSVParser(IFormFile file);

        /// <summary>
        /// Parse airport's file from xml
        /// </summary>
        public Task AirportXMLParser(IFormFile file);
        /// <summary>
        /// Interface of Exporting airport datas
        /// </summary>
        public Task<IAirport[]> ExportAirportExcel();
    }
}
