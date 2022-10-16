using iTechArt.Data.DbContexts;
using iTechArt.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iTechArt.Data.Repositories
{
    public class Repository<TSource> : IRepository<TSource> where TSource : class
    {
        protected readonly AppDbContext dbContext;
        protected readonly DbSet<TSource> dbSet;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TSource>();
        }

        public async ValueTask<TSource> AddAsync(TSource entity)
        {
            var entry = await dbSet.AddAsync(entity);

            return entry.Entity;
        }

        public void Delete(TSource entity)
            => dbSet.Remove(entity);

        public List<TSource> GetAll(Expression<Func<TSource, bool>> expression = null)
        {
            var query = expression is null ? dbSet : dbSet.Where(expression);

            return query.ToList();
        }

        public async ValueTask<TSource> GetAsync(Expression<Func<TSource, bool>> expression)
            => await dbSet.FirstOrDefaultAsync(expression);

        public TSource Update(TSource entity)
            => dbSet.Update(entity).Entity;

        public async ValueTask SaveChangesAsync()
            => await dbContext.SaveChangesAsync();
    }
}
