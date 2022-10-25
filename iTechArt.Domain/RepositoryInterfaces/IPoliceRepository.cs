using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPoliceRepository
    {
        /// <summary>
        /// Get all entities from database
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        IPolice[] GetAll();

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>
        Task AddAsync(IPolice entity);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resopisitory model interface </returns>
        Task<IPolice> GetByIdAsync(long id);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(IPolice entity);

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAsync(IPolice entity);

        /// </summary>
        /// Get count of polices
        /// </summary>
        public int GetCountOfPolice();
    }
}
