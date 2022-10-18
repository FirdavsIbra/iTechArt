using iTechArt.Data.DbContexts;
using iTechArt.Data.IRepositories;
using iTechArt.Domain.Entities.Police;

namespace iTechArt.Data.Repositories
{
    public class PoliceRepository : Repository<Police>, IPoliceRepository
    {
        public PoliceRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
