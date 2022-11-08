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
        public async Task AddAsync(IAirport airport)
        {
            await _dbContext.Airports.AddAsync(_mapper.Map<AirportDb>(airport));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all airports from database
        /// </summary>
        public async Task<IAirport[]> GetAllAsync()
        {
            return await _dbContext.Airports.Select(a => _mapper.Map<Airport>(a)).ToArrayAsync();
        }

        /// <summary>
        /// Get airport by id
        /// </summary>
        public async Task<IAirport> GetByIdAsync(long id)
        {
           return await _dbContext.Airports.Select(a => _mapper.Map<Airport>(a))
                                           .FirstOrDefaultAsync(a => a.Id == id);
        }

        /// <summary>
        /// Update airport
        /// </summary>
        public async Task UpdateAsync(IAirport airport)
        {
            _dbContext.Airports.Update(_mapper.Map<AirportDb>(airport));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete airport from database
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var airport = await _dbContext.Airports.FirstOrDefaultAsync(a => a.Id == id);
            if (airport != null)
            {
                _dbContext.Airports.Remove(_mapper.Map<AirportDb>(airport));
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get total count of airport
        /// </summary>
        public async Task<int> GetCountOfAirportAsync()
        {
            return await _dbContext.Airports.CountAsync();
        }

        /// <summary>
        /// Add airport array
        /// </summary>
        public async Task AddRangeAsync(IEnumerable<IAirport> airports) 
        {
            await _dbContext.Airports.AddRangeAsync(airports.Select(_mapper.Map<AirportDb>));
            await _dbContext.SaveChangesAsync();
        }
    }

}
