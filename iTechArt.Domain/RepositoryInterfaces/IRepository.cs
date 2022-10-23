using iTechArt.Database.DbContexts;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IRepository<RepoModel, DatabaseModel> 
        where RepoModel : class 
        where DatabaseModel: class, IDbModel
    {
        /// <summary>
        /// Get all entities from database
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        RepoModel[] GetAll();

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Resopisitory model interface </returns>
        Task<RepoModel> AddAsync(DatabaseModel entity);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resopisitory model interface </returns>
        Task<RepoModel> GetByIdAsync(long id);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Resopisitory model interface </returns>
        Task<RepoModel> UpdateAsync(DatabaseModel entity);

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Resopisitory model interface </returns>
        Task DeleteAsync(DatabaseModel entity);
    }
}
