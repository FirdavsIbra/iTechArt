using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Students;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public class StudentRepository : Repository<IStudent>, IStudentRepository
    {
        /// <summary>
        /// Dbcontext instance injected
        /// </summary>
        /// <param name="dbContext"></param>
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Get total count of students
        /// </summary>
        /// <returns></returns>
        public int GetCountOfStudents()
        {
            return _dbContext.Set<Students>().Count();
        }
    }
}
