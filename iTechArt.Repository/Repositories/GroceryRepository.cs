using iTechArt.Database.DbContexts;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public class GroceryRepository : Repository<IGrocery>, IGroceryRepository
    {
        public GroceryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
