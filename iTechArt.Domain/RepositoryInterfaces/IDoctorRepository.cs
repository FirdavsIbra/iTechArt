using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        public int GetCountOfDoctors();
    }
}
