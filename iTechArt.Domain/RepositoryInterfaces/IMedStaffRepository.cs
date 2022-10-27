using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IMedStaffRepository
    {
        /// <summary>
        /// Get all doctors from database
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        IMedStaff[] GetAll();

        /// <summary>
        /// Add doctor to database
        /// </summary>
        /// <param name="doctor"></param>
        Task AddAsync(IMedStaff doctor);

        /// <summary>
        /// Get doctor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resopisitory model interface </returns>
        Task<IMedStaff> GetByIdAsync(long id);

        /// <summary>
        /// Update doctor
        /// </summary>
        /// <param name="doctor"></param>
        Task UpdateAsync(IMedStaff doctor);

        /// <summary>
        /// Delete doctor from database
        /// </summary>
        Task DeleteAsync(long id);

        /// </summary>
        /// Get count of doctors
        /// </summary>
        public int GetCountOfDoctors();
    }
}
