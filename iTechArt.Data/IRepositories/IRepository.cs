using System.Linq.Expressions;

namespace iTechArt.Data.IRepositories
{
    public interface IRepository<TSource> where TSource : class
    {
        List<TSource> GetAll(Expression<Func<TSource, bool>> expression = null);
        ValueTask<TSource> AddAsync(TSource entity);
        ValueTask<TSource> GetAsync(Expression<Func<TSource, bool>> expression);
        TSource Update(TSource entity);
        void Delete(TSource entity);
        ValueTask SaveChangesAsync();
    }
}
