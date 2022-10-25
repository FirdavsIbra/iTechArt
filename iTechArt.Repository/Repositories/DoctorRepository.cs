using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Repository.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public DoctorRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Add doctor to database
        /// </summary>
        /// <param name="doctor"></param>   
        public async Task AddAsync(IDoctor doctor)
        {
            await _dbContext.Set<DoctorDb>().AddAsync(_mapper.Map<DoctorDb>(doctor));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all doctors from database
        /// </summary>
        public IDoctor[] GetAll()
        {
            var doctors = _dbContext.Set<DoctorDb>();

            List<IDoctor> result = new List<IDoctor>();

            foreach (var doctor in doctors)
            {
                result.Add(_mapper.Map<Doctor>(doctor));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Get doctor by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IDoctor> GetByIdAsync(long id)
        {
            var doctorDb = await _dbContext.Set<DoctorDb>().FirstOrDefaultAsync(d => d.Id == id);

            return _mapper.Map<Doctor>(doctorDb);
        }

        /// <summary>
        /// Update doctor
        /// </summary>
        /// <param name="doctor"></param>
        public async Task UpdateAsync(IDoctor doctor)
        {
            _dbContext.Set<DoctorDb>().Update(_mapper.Map<DoctorDb>(doctor));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete doctor from database
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var doctor = await _dbContext.Set<DoctorDb>().FirstOrDefaultAsync(d => d.Id == id);

            _dbContext.Set<DoctorDb>().Remove(_mapper.Map<DoctorDb>(doctor));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of doctors
        /// </summary>
        public int GetCountOfDoctors()
        {
            return _dbContext.Set<DoctorDb>().Count();
        }
    }
}
