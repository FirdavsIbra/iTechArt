using iTechArt.Database.DbContexts;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public class PupilRepository : Repository<IPupil>, IPupilRepository
    {
        public PupilRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
