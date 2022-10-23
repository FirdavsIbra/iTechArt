using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Airports;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public class AirportRepository : Repository<IAirport, Airport>, IAirportRepository
    {
        public AirportRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        /// <summary>
        /// Get total count of airport
        /// </summary>
        /// <returns></returns>
        public int GetCountOfAirport()
        {
            return _dbContext.Set<Airport>().Count();
        }
    }
}
