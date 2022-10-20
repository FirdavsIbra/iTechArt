using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Database.DbContexts;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Database.Entities.Police;

namespace iTechArt.Repository.Repositories
{
    public sealed class PoliceRepository : Repository<IPolice>, IPoliceRepository
    {
        public PoliceRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Get total count of police
        /// </summary>
        /// <returns></returns>
        public int GetCountOfPolice()
        {
            return _dbContext.Set<Police>().Count();
        }
    }
}
