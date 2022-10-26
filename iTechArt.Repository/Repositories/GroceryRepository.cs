using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Groceries;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
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
        /// Add grocery to database
        /// </summary>
        /// <param name="grocery"></param>   
        public async Task AddAsync(IGrocery grocery)
        {
            await _dbContext.Set<GroceryDb>().AddAsync(_mapper.Map<GroceryDb>(grocery));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all entities from database
        /// </summary>
        public IGrocery[] GetAll()
        {
            var groceries = _dbContext.Set<GroceryDb>();

            List<IGrocery> result = new List<IGrocery>();

            foreach (var grocery in groceries)
            {
                result.Add(_mapper.Map<Grocery>(grocery));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Get grocery by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IGrocery> GetByIdAsync(long id)
        {
            var groceryDb = await _dbContext.Set<GroceryDb>().FirstOrDefaultAsync(g => g.Id == id);

            return _mapper.Map<Grocery>(groceryDb);
        }

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
            var grocery = await _dbContext.Set<MedStaffDb>().FirstOrDefaultAsync(g => g.Id == id);

            _dbContext.Set<IGrocery>().Remove(_mapper.Map<IGrocery>(grocery));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of groceries
        /// </summary>
        public int GetCountOfGrocery()
        {
            return _dbContext.Set<GroceryDb>().Count();
        }
    }
}
