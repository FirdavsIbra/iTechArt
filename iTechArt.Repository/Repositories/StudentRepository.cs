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
        public StudentRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Add student to database.
        /// </summary>
        public async Task AddAsync(IStudent entity)
        {
            await _dbContext.Students.AddAsync(_mapper.Map<StudentDb>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all students from database.
        /// </summary>
        public async Task<IStudent[]> GetAllAsync()
        {
            return await _dbContext.Students.Select(s => _mapper.Map<Student>(s))
                                            .ToArrayAsync();
        }

        /// <summary>
        /// Get entity by id.
        /// </summary>
        public async Task<IStudent> GetByIdAsync(long id)
        {
            return await _dbContext.Students.Select(s => _mapper.Map<Student>(s))
                                            .FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Update student.
        /// </summary>
        public async Task UpdateAsync(IStudent entity)
        {
            _dbContext.Students.Update(_mapper.Map<StudentDb>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete student from database.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(d => d.Id == id);

            if (student is not null)
            {
                _dbContext.Students.Remove(_mapper.Map<StudentDb>(student));
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get total count of students.
        /// </summary>
        public async Task<int> GetCountOfStudentsAsync()
        {
            return await _dbContext.Students.CountAsync();
        }

        /// <summary>
        /// Add student array.
        /// </summary>
        public async Task AddRangeAsync(IEnumerable<IStudent> pupils)
        {
            await _dbContext.Students.AddRangeAsync(pupils.Select(_mapper.Map<StudentDb>));

            await _dbContext.SaveChangesAsync();
        }
    }
}
