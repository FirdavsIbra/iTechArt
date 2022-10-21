namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IRepository<TSource> where TSource : class
    {
        /// <summary>
        /// Get all entities from database
        /// </summary>
        /// <returns></returns>
        Task<List<TSource>> GetAllAsync();

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TSource> AddAsync(TSource entity);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TSource> GetByIdAsync(long id);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TSource> UpdateAsync(TSource entity);

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TSource entity);
    }
}
