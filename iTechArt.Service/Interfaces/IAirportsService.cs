namespace iTechArt.Service.Interfaces
{
    public interface IAirportsService
    {
        public Task<List<string>> ImportAirportExcel();
        public Task<List<string>> ExportAirportExcel();
    }
}
