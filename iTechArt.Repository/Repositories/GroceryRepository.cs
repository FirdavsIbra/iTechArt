using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Groceries;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels.HelperModels;
using iTechArt.Repository.BusinessModels;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Repository.Repositories
{
    public class GroceryRepository : IGroceryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public GroceryRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all entities from database
        /// </summary>
        public async Task<IGrocery[]> GetAllAsync()
        {
            var groceries = await _dbContext.Groceries.ToArrayAsync();

            IGrocery[] result = new IGrocery[_dbContext.Groceries.Count()];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = _mapper.Map<Grocery>(groceries[i]);
            }

            return result;
        }

        /// <summary>
        /// Get grocery by id
        /// </summary>
        /// <param name="id"></param>
        //public async Task<IGrocery> GetByIdAsync(long id)
        //{
        //    var groceryDb = await _dbContext.Set<GroceryDb>().FirstOrDefaultAsync(g => g.Id == id);

        //    return _mapper.Map<Grocery>(groceryDb);
        //}

        /// <summary>
        /// Update grocery
        /// </summary>
        /// <param name="grocery"></param>
        public async Task UpdateAsync(IGrocery grocery)
        {
            _dbContext.Set<GroceryDb>().Update(_mapper.Map<GroceryDb>(grocery));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete grocery from database
        /// </summary>
        /// <param name="grocery"></param>
        public async Task DeleteAsync(long id)
        {
        }
        public async Task<IDbResult> AddGroceriesAsync(IEnumerable<IGrocery> groceries)
        {
            try
            {
                await _dbContext.AddRangeAsync(_mapper.Map<GroceryDb>(groceries));
                await _dbContext.SaveChangesAsync();
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
        /// Get total count of groceries
        /// </summary>
        public int GetCountOfGrocery()
        {
            return _dbContext.Groceries.Count();
        }
    }
}