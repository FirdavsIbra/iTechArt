using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPupilService
    {
        /// <summary>
        /// Upload pupil's file
        /// </summary>
        public IPupil[] ImportPupilsFile();
        
        /// <summary>
        /// Get all pupils
        /// </summary>
        public IPupil[] GetAllAsync();
        
        /// <summary>
        /// Get pupil by id
        /// </summary>
        /// <param name="id"></param>
        public Task<IPupil> GetByIdAsync(long id);

        /// <summary>
        /// Add pupil to database
        /// </summary>
        /// <param name="pupil"></param>
        public Task AddAsync(IPupil pupil);

        /// <summary>
        /// Delete pupil from database
        /// </summary>
        /// <param name="id"></param>
        public Task DeleteAsync(long id);
        
    }
}
