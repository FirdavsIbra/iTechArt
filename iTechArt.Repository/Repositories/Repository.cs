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

        public async Task<TSource> AddAsync(TSource entity)
        {
            var entry = await _dbContext.Set<TSource>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<List<TSource>> GetAllAsync()
        {
            return await _dbContext.Set<TSource>().ToListAsync();
        }

        public async Task<TSource> GetByIdAsync(long id)
        {
            return await _dbContext.Set<TSource>().FindAsync(id);
        }

        public async Task<TSource> UpdateAsync(TSource entity)
        {
            var entry = _dbContext.Set<TSource>().Update(entity);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task DeleteAsync(TSource entity)
        {
            _dbContext.Set<TSource>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}