using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Repository.Repositories
{
    public sealed class MedStaffRepository : IMedStaffRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public MedStaffRepository(AppDbContext dbContext, IMapper mapper)
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
            var mappedMedStaff = _mapper.Map<MedStaffDb>(doctor);

            await _dbContext.Staffs.AddAsync(mappedMedStaff);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all doctors from database
        /// </summary>
        public async Task<IMedStaff[]> GetAll()
        {
            var doctors = await _dbContext.Staffs.ToArrayAsync();

            IMedStaff[] result = new IMedStaff[_dbContext.Staffs.Count()];

            for(var i = 0; i < result.Length; i++)
            {
                result[i] = _mapper.Map<IMedStaff>(doctors[i]);
            }

            return result;
        }

        /// <summary>
        /// Get doctor by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IMedStaff> GetByIdAsync(long id)
        {
            var doctorDb = await _dbContext.Staffs.FirstOrDefaultAsync(d => d.Id == id);

            return _mapper.Map<MedStaff>(doctorDb);
        }

        /// <summary>
        /// Update doctor
        /// </summary>
        /// <param name="doctor"></param>
        public async Task UpdateAsync(IMedStaff doctor)
        {
            var mappedMedStaff = _mapper.Map<MedStaffDb>(doctor);

            _dbContext.Staffs.Update(mappedMedStaff);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete doctor from database
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var doctor = await _dbContext.Staffs.FirstOrDefaultAsync(d => d.Id == id);

            _dbContext.Staffs.Remove(_mapper.Map<MedStaffDb>(doctor));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of doctors
        /// </summary>
        public int GetCountOfDoctors()
        {
            return _dbContext.Staffs.Count();
        }
    }
}
