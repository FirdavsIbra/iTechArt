using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Groceries;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels.HelperModels;

namespace iTechArt.Repository.Repositories
{
    public class GroceryRepository : Repository<IGrocery, Grocery>, IGroceryRepository
    {
        public GroceryRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<IDbResult> AddGroceriesAsync(List<IGrocery> groceries)
        {
            try
            {
                await _dbContext.AddRangeAsync(groceries);
                return new DbResult
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {

               return new DbResult {
                    IsSuccess = false,
                    Exception = ex
                };
            }
        }
        /// <summary>
        /// Get total count of grocery
        /// </summary>
        public int GetCountOfGrocery()
        {
            return _dbContext.Set<Grocery>().Count();
        }
    }
}