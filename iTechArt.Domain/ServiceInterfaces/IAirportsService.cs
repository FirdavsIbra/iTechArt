namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IAirportsService
    {
        public Task<List<string>> ImportAirportExcel();
        public Task<List<string>> ExportAirportExcel();
    }
}
