using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Pupils;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public sealed class PupilRepository : Repository<IPupil, Pupil>, IPupilRepository
    {
        public PupilRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
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
