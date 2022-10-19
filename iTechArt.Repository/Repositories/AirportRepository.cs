using iTechArt.Database.DbContexts;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public class AirportRepository : Repository<IAirport>, IAirportRepository
    {
        public AirportRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
