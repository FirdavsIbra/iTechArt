using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IMedStaffService
    {
        public ValueTask<List<string>> ImportMedStaffFile();

        public ValueTask<List<Doctor>> ExportMedStaffFile();
    }
}
