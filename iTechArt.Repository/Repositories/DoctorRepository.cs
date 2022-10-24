using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public class DoctorRepository : Repository<IDoctor, Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        /// <summary>
        /// Get total count of medstaff
        /// </summary>
        public int GetCountOfDoctors()
        {
            return _dbContext.Set<Doctor>().Count();
        }
    }
}
