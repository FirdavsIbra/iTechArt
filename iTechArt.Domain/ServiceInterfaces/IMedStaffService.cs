namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IMedStaffService
    {
        public ValueTask<List<string>> ImportMedStaffFile();

        public ValueTask<List<string>> ExportMedStaffFile();
    }
}
