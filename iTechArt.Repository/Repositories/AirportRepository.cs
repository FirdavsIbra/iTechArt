using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Airports;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using Microsoft.EntityFrameworkCore;

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
        /// Add airport to database
        /// </summary>
        /// <param name="airport"></param>   
        public async Task AddAsync(IAirport airport)
        {
            await _dbContext.Set<AirportDb>().AddAsync(_mapper.Map<AirportDb>(airport));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all airports from database
        /// </summary>
        public IAirport[] GetAll()
        {
            var airports = _dbContext.Set<AirportDb>();

            List<IAirport> result = new List<IAirport>();

            foreach (var airport in airports)
            {
                result.Add(_mapper.Map<Airport>(airport));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Get airport by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IAirport> GetByIdAsync(long id)
        {
            var airportDb = await _dbContext.Set<AirportDb>().FirstOrDefaultAsync(a => a.Id == id);

            return _mapper.Map<Airport>(airportDb);
        }

        /// <summary>
        /// Update airport
        /// </summary>
        /// <param name="airport"></param>
        public async Task UpdateAsync(IAirport airport)
        {
            _dbContext.Set<AirportDb>().Update(_mapper.Map<AirportDb>(airport));

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
            return _dbContext.Set<AirportDb>().Count();
        }
    }
}
