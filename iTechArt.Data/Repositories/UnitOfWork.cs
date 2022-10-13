using iTechArt.Data.DbContexts;
using iTechArt.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Police = new PoliceRepository(dbContext);

        }

        public IPoliceRepository Police { get; private set; }
    }
}
