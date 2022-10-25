using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Students;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using Microsoft.EntityFrameworkCore;

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
        /// Add student to database
        /// </summary>
        /// <param name="student"></param>   
        public async Task AddAsync(IStudent student)
        {
            await _dbContext.Set<StudentDb>().AddAsync(_mapper.Map<StudentDb>(student));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all students from database
        /// </summary>
        public IStudent[] GetAll()
        {
            var students = _dbContext.Set<StudentDb>();

            List<IStudent> result = new List<IStudent>();

            foreach (var student in students)
            {
                result.Add(_mapper.Map<Student>(student));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Get student by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IStudent> GetByIdAsync(long id)
        {
            var studentDb = await _dbContext.Set<StudentDb>().FirstOrDefaultAsync(s => s.Id == id);

            return _mapper.Map<Student>(studentDb);
        }

        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="student"></param>
        public async Task UpdateAsync(IStudent student)
        {
            _dbContext.Set<StudentDb>().Update(_mapper.Map<StudentDb>(student));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete student from database
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var student = await _dbContext.Set<StudentDb>().FirstOrDefaultAsync(s => s.Id == id);

            _dbContext.Set<StudentDb>().Remove(_mapper.Map<StudentDb>(student));

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
