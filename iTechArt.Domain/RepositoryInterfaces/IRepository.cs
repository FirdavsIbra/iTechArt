namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IRepository<TSource> where TSource : class
    {
        Task<List<TSource>> GetAllAsync();
        Task<TSource> AddAsync(TSource entity);
        Task<TSource> GetByIdAsync(long id);
        Task<TSource> UpdateAsync(TSource entity);
        Task DeleteAsync(TSource entity);
    }
}
