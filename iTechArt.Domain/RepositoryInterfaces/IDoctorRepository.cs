using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IDoctorRepository
    {
        /// <summary>
        /// Get all entities from database
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        IDoctor[] GetAll();

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>
        Task AddAsync(IDoctor entity);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resopisitory model interface </returns>
        Task<IDoctor> GetByIdAsync(long id);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(IDoctor entity);

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAsync(IDoctor entity);

        /// </summary>
        /// Get count of doctors
        /// </summary>
        public int GetCountOfDoctors();
    }
}
