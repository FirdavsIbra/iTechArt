using iTechArt.Database.DbContexts;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Database.Entities.Police;
using AutoMapper;

namespace iTechArt.Repository.Repositories
{
    public sealed class PoliceRepository : Repository<IPolice, Police>, IPoliceRepository
    {
        public PoliceRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        /// <summary>
        /// Get total count of police
        /// </summary>
        public int GetCountOfPolice()
        {
            return _dbContext.Set<Police>().Count();
        }
    }
}
