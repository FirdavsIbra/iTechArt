using iTechArt.Database.Entities.Students;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IStudentRepository : IRepository<IStudent, Students>
    {
        /// </summary>
        /// Get count of students
        /// </summary>
        public int GetCountOfStudents();
    }
}
