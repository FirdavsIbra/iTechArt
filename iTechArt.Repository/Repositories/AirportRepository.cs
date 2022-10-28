using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Airports;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Repository.Repositories
{
    public sealed class AirportRepository : IAirportRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public AirportRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Add airport to database
        /// </summary>
        /// <param name="airport"></param>   
        public async Task AddAsync(IAirport airport)
        {
            var entry = await _dbContext.Set<AirportDb>().AddAsync(_mapper.Map<AirportDb>(airport));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all airports from database
        /// </summary>
        public async Task<IAirport[]> GetAll()
        {
            var airports = await _dbContext.Airports.ToArrayAsync();

            IAirport[] result = new IAirport[_dbContext.Airports.Count()];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = _mapper.Map<IAirport>(airports[i]);
            }

            return result;
        }

        /// <summary>
        /// Get airport by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IAirport> GetByIdAsync(long id)
        {
            var databaseModel = await _dbContext.Set<AirportDb>().FindAsync(id);

            if (databaseModel is null)
                return null;

            return _mapper.Map<IAirport>(databaseModel);
        }

        /// <summary>
        /// Update airport
        /// </summary>
        /// <param name="airport"></param>
        public async Task UpdateAsync(IAirport airport)
        {
            var entry = _dbContext.Set<AirportDb>().Update(_mapper.Map<AirportDb>(airport));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete airport from database
        /// </summary>
        /// <param name="airport"></param>
        public async Task DeleteAsync(IAirport airport)
        {
            _dbContext.Set<AirportDb>().Remove(_mapper.Map<AirportDb>(airport));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of airport
        /// </summary>
        public int GetCountOfAirport()
        {
            return _dbContext.Airports.Count();
        }
    }
}
