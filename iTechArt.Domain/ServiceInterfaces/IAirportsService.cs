using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IAirportsService
    {
        public IAirport[] ImportAirportExcel();
        public IAirport[] ExportAirportExcel();
    }
}
