using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IStudentRepository : IRepository<IStudent>
    {
        /// <summary>
        /// Return Number Of Students
        /// </summary>
        public int GetCountOfStudents();
    }
}
