using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPupilRepository
    {
        /// <summary>
        /// Add pupil to database
        /// </summary>
        /// <param name="pupil"></param>
        public Task AddAsync(IPupil pupil);

        /// <summary>
        /// Get all pupils
        /// </summary>
        public IPupil[] GetAll();

        /// <summary>
        /// Get pupil by id
        /// </summary>
        /// <param name="id"></param>
        public Task<IPupil> GetByIdAsync(long id);

        /// <summary>
        /// Update pupil
        /// </summary>
        /// <param name="pupil"></param>
        public Task UpdateAsync(IPupil pupil);

        /// <summary>
        /// Delete pupil from database
        /// </summary>
        /// <param name="pupil"></param>
        public Task DeleteAsync(IPupil pupil);

        /// </summary>
        /// Get count of pupils
        /// </summary>
        public int GetCountOfPupils();
    }
}
