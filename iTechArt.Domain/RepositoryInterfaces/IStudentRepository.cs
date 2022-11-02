using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IStudentRepository
    {
        /// <summary>
        /// Get all students from database
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        public IStudents[] GetAll();

        /// <summary>
        /// Add student to database
        /// </summary>
        /// <param name="student"></param>
        public Task AddAsync(IStudents student);

        /// <summary>
        /// Get student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resopisitory model interface </returns>
        public Task<IStudents> GetByIdAsync(long id);

        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="student"></param>
        public Task UpdateAsync(IStudents student);

        /// <summary>
        /// Delete student from database
        /// </summary>
        public Task DeleteAsync(long id);

        /// </summary>
        /// Get count of students
        /// </summary>
        public int GetCountOfStudents();
    }
}
