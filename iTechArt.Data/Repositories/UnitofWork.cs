using iTechArt.Data.DbContexts;
using iTechArt.Data.IRepositories;

namespace iTechArt.Data.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _dbContext;

        public UnitofWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Police = new PoliceRepository(dbContext);

        }

        public IPoliceRepository Police { get; private set; }
    }
}
