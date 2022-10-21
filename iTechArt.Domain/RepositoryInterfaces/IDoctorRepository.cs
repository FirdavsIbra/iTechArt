using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        /// </summary>
        /// Get count of doctors
        /// </summary>
        /// <returns></returns>
        public int GetCountOfDoctors();
    }
}
