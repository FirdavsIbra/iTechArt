using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IAirportsService
    {
        /// <summary>
        /// Interface of Importing airport datas
        /// </summary>

        public IAirport[] ImportAirportExcel();

        /// <summary>
        /// Interface of Exporting airport datas
        /// </summary>

        public IAirport[] ExportAirportExcel();
    }
}
