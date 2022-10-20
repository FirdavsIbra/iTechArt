using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Pupils;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public class PupilRepository : Repository<Pupil>, IPupilRepository
    {
        public PupilRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public int GetCountOfPupils()
        {
            return _dbContext.Set<Pupil>().Count();
        }
    }
}
