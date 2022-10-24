using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IDoctorRepository : IRepository<IDoctor, Doctor>
    {
        /// </summary>
        /// Get count of doctors
        /// </summary>
        public int GetCountOfDoctors();
    }
}
