using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public class DoctorRepository : Repository<IDoctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public int CountNumberOfDoctors()
        {
            return _dbContext.Set<Doctor>().Count();
        }
    }
}
