using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IStudentRepository
    {
        /// <summary>
        /// Get all entities from database
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        IStudent[] GetAll();

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>
        Task AddAsync(IStudent entity);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resopisitory model interface </returns>
        Task<IStudent> GetByIdAsync(long id);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(IStudent entity);

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAsync(IStudent entity);

        /// </summary>
        /// Get count of students
        /// </summary>
        public int GetCountOfStudents();
    }
}
