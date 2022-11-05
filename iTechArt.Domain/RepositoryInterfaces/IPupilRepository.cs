using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPupilRepository
    {
        /// <summary>
        /// Add pupil to database
        /// </summary>
        public Task AddAsync(IPupil pupil);

        /// <summary>
        /// Get all pupils
        /// </summary>
        public Task<IPupil[]> GetAllAsync();

        /// <summary>
        /// Get pupil by id
        /// </summary>
        public Task<IPupil> GetByIdAsync(long id);
        
        /// <summary>
        /// Add pupil array
        /// </summary>
        public Task AddRangeAsync(IPupil[] pupils);

        /// <summary>
        /// Update pupil
        /// </summary>
        public Task UpdateAsync(IPupil pupil);

        /// <summary>
        /// Delete pupil from database
        /// </summary>
        public Task DeleteAsync(long id);

        /// </summary>
        /// Get count of pupils
        /// </summary>
        public Task<int> GetCountOfPupilsAsync();
    }
}
