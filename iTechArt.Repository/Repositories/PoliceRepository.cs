using iTechArt.Database.DbContexts;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public sealed class PoliceRepository : Repository<IPolice>, IPoliceRepository
    {
        public PoliceRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
