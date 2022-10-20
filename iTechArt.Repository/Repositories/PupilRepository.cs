using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Pupils;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public sealed class PupilRepository : Repository<Pupil>, IPupilRepository
    {
        public PupilRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Get total count of pupils
        /// </summary>
        /// <returns></returns>
        public int GetCountOfPupils()
        {
            return _dbContext.Set<Pupil>().Count();
        }
    }
}
