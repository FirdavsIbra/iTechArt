using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Students;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Dbcontext instance injected
        /// </summary>
        /// <param name="dbContext"></param>
        public StudentRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>   
        public async Task AddAsync(IStudent entity)
        {
            var entry = await _dbContext.Set<StudentDb>().AddAsync(_mapper.Map<StudentDb>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all entities from database
        /// </summary>
        public IStudent[] GetAll()
        {
            var models = _dbContext.Set<StudentDb>();

            List<IStudent> result = new List<IStudent>();

            foreach (var i in models)
            {
                result.Add(_mapper.Map<IStudent>(i));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IStudent> GetByIdAsync(long id)
        {
            var databaseModel = await _dbContext.Set<StudentDb>().FindAsync(id);

            if (databaseModel is null)
                return null;

            return _mapper.Map<IStudent>(databaseModel);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public async Task UpdateAsync(IStudent entity)
        {
            var entry = _dbContext.Set<StudentDb>().Update(_mapper.Map<StudentDb>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        public async Task DeleteAsync(IStudent entity)
        {
            _dbContext.Set<StudentDb>().Remove(_mapper.Map<StudentDb>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of students
        /// </summary>
        /// <returns></returns>
        public int GetCountOfStudents()
        {
            return _dbContext.Set<StudentDb>().Count();
        }
    }
}
