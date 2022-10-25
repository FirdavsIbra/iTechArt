using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Groceries;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

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
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>   
        public async Task AddAsync(IGrocery entity)
        {
            var entry = await _dbContext.Set<Grocery>().AddAsync(_mapper.Map<Grocery>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all entities from database
        /// </summary>
        public IGrocery[] GetAll()
        {
            var models = _dbContext.Set<Grocery>();

            List<IGrocery> result = new List<IGrocery>();

            foreach (var i in models)
                result.Add(_mapper.Map<IGrocery>(i));

            return result.ToArray();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IGrocery> GetByIdAsync(long id)
        {
            var databaseModel = await _dbContext.Set<Grocery>().FindAsync(id);

            if (databaseModel is null)
                return null;

            return _mapper.Map<IGrocery>(databaseModel);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public async Task UpdateAsync(IGrocery entity)
        {
            var entry = _dbContext.Set<Grocery>().Update(_mapper.Map<Grocery>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        public async Task DeleteAsync(IGrocery entity)
        {
            _dbContext.Set<IGrocery>().Remove(_mapper.Map<IGrocery>(entity));

            await _dbContext.SaveChangesAsync();
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
