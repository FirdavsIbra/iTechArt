using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Airports;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public AirportRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>   
        public async Task AddAsync(IAirport entity)
        {
            var entry = await _dbContext.Set<Airport>().AddAsync(_mapper.Map<Airport>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all entities from database
        /// </summary>
        public IAirport[] GetAll()
        {
            var models = _dbContext.Set<Airport>();

            List<IAirport> result = new List<IAirport>();

            foreach (var i in models)
                result.Add(_mapper.Map<IAirport>(i));

            return result.ToArray();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IAirport> GetByIdAsync(long id)
        {
            var databaseModel = await _dbContext.Set<Airport>().FindAsync(id);

            if (databaseModel is null)
                return null;

            return _mapper.Map<IAirport>(databaseModel);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public async Task UpdateAsync(IAirport entity)
        {
            var entry = _dbContext.Set<Airport>().Update(_mapper.Map<Airport>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        public async Task DeleteAsync(IAirport entity)
        {
            _dbContext.Set<Airport>().Remove(_mapper.Map<Airport>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of airport
        /// </summary>
        public int GetCountOfAirport()
        {
            return _dbContext.Set<Airport>().Count();
        }
    }
}
