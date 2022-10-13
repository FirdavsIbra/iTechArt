using iTechArt.Data.DbContexts;
using iTechArt.Data.IRepositories;
using iTechArt.Domain.Entities.Police;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Data.Repositories
{
    public class PoliceRepository : Repository<Police>, IPoliceRepository
    {
        public PoliceRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
