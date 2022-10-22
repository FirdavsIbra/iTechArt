using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Groceries;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public class GroceryRepository : Repository<IGrocery, Grocery>, IGroceryRepository
    {
        public GroceryRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        /// <summary>
        /// Get total count of grocery
        /// </summary>
        /// <returns></returns>
        public int GetCountOfGrocery()
        {
            return _dbContext.Set<Grocery>().Count();
        }
    }
}
