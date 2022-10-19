using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Database.Entities.Police;
using iTechArt.Database.DbContexts;

namespace iTechArt.Repository.Repositories
{
    public class PoliceRepository : Repository<Police>, IPoliceRepository
    {
        public PoliceRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
