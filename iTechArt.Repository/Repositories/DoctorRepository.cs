using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

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
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>   
        public async Task AddAsync(IDoctor entity)
        {
            var entry = await _dbContext.Set<Doctor>().AddAsync(_mapper.Map<Doctor>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all entities from database
        /// </summary>
        public IDoctor[] GetAll()
        {
            var models = _dbContext.Set<Doctor>();

            List<IDoctor> result = new List<IDoctor>();

            foreach (var i in models)
                result.Add(_mapper.Map<IDoctor>(i));

            return result.ToArray();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IDoctor> GetByIdAsync(long id)
        {
            var databaseModel = await _dbContext.Set<Doctor>().FindAsync(id);

            if (databaseModel is null)
                return null;

            return _mapper.Map<IDoctor>(databaseModel);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public async Task UpdateAsync(IDoctor entity)
        {
            var entry = _dbContext.Set<Doctor>().Update(_mapper.Map<Doctor>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        public async Task DeleteAsync(IDoctor entity)
        {
            _dbContext.Set<Doctor>().Remove(_mapper.Map<Doctor>(entity));

            await _dbContext.SaveChangesAsync();
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
