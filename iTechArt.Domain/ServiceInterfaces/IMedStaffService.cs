using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IMedStaffService
    {
        public ValueTask<List<IDoctor>> ImportMedStaffFile();

        public ValueTask<List<string>> ExportMedStaffFile();
    }
}
