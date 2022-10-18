namespace iTechArt.Service.Interfaces
{
    public interface IMedStaffService
    {
        public ValueTask<List<string>> ImportMedStaffFile();

        public ValueTask<List<string>> ExportMedStaffFile();
    }
}
