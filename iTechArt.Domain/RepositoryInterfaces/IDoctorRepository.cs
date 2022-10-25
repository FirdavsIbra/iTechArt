using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IDoctorRepository
    {
        /// <summary>
        /// Get all doctors from database
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        IDoctor[] GetAll();

        /// <summary>
        /// Add doctor to database
        /// </summary>
        /// <param name="doctor"></param>
        Task AddAsync(IDoctor doctor);

        /// <summary>
        /// Get doctor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resopisitory model interface </returns>
        Task<IDoctor> GetByIdAsync(long id);

        /// <summary>
        /// Update doctor
        /// </summary>
        /// <param name="doctor"></param>
        Task UpdateAsync(IDoctor doctor);

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
