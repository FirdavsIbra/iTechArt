using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Repository.Repositories
{
    public class DoctorRepository : IMedStaffRepository
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
        public async Task AddAsync(IMedStaff doctor)
        {
            await _dbContext.Set<MedStaffDb>().AddAsync(_mapper.Map<MedStaffDb>(doctor));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all doctors from database
        /// </summary>
        public IMedStaff[] GetAll()
        {
            var doctors = _dbContext.Set<MedStaffDb>();

            List<IMedStaff> result = new List<IMedStaff>();

            foreach (var doctor in doctors)
            {
                result.Add(_mapper.Map<MedStaff>(doctor));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Get doctor by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IMedStaff> GetByIdAsync(long id)
        {
            var doctorDb = await _dbContext.Set<MedStaffDb>().FirstOrDefaultAsync(d => d.Id == id);

            return _mapper.Map<MedStaff>(doctorDb);
        }

        /// <summary>
        /// Update doctor
        /// </summary>
        /// <param name="doctor"></param>
        public async Task UpdateAsync(IMedStaff doctor)
        {
            _dbContext.Set<MedStaffDb>().Update(_mapper.Map<MedStaffDb>(doctor));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete doctor from database
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var doctor = await _dbContext.Set<MedStaffDb>().FirstOrDefaultAsync(d => d.Id == id);

            _dbContext.Set<MedStaffDb>().Remove(_mapper.Map<MedStaffDb>(doctor));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of doctors
        /// </summary>
        public int GetCountOfDoctors()
        {
            return _dbContext.Set<MedStaffDb>().Count();
        }
    }
}
