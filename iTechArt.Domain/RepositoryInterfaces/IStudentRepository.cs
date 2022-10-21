using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IStudentRepository : IRepository<IStudent>
    {
        /// <summary>
        /// Get count of students
        /// </summary>
        /// <returns></returns>
        public int GetCountOfStudents();
    }
}
