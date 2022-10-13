namespace iTechArt.Service.Interfaces
{
    public interface IAirportsService
    {
        List<string> ImportAirportExcel();
        List<string> ExportAirportExcel();
    }
}
