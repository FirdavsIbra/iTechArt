namespace iTechArt.Service.Interfaces
{
    public interface IAirportsService
    {
        public List<string> ImportAirportExcel();
        public List<string> ExportAirportExcel();
    }
}
