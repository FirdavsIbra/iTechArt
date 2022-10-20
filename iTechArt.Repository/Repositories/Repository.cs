using iTechArt.Database.DbContexts;
using iTechArt.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Repository.Repositories
{
    public abstract class Repository<TSource> : IRepository<TSource> where TSource : class
    {
        protected readonly AppDbContext _dbContext;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TSource> AddAsync(TSource entity)
        {
            var entry = await _dbContext.Set<TSource>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
        
        /// <summary>
        /// Get all entities from database
        /// </summary>
        /// <returns></returns>
        public async Task<List<TSource>> GetAllAsync()
        {
            return await _dbContext.Set<TSource>().ToListAsync();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TSource> GetByIdAsync(long id)
        {
            return await _dbContext.Set<TSource>().FindAsync(id);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TSource> UpdateAsync(TSource entity)
        {
            var entry = _dbContext.Set<TSource>().Update(entity);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteAsync(TSource entity)
        {
            _dbContext.Set<TSource>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}