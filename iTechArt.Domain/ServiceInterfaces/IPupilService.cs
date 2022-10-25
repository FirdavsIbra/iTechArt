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
        public Task AddAsync(IPupil pupil);
        public Task DeleteAsync(long id);
        
    }
}
