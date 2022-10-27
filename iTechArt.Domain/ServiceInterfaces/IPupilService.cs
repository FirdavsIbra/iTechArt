using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPupilService
    {
        /// <summary>
        /// Upload pupil's file
        /// </summary>
        public Task ImportPupilsFileAsync();

        /// <summary>
        /// Get all pupils
        /// </summary>
        public Task<IPupil[]> GetAllAsync();

        /// <summary>
        /// Get pupil by id
        /// </summary>
        public Task<IPupil> GetByIdAsync(long id);
    }
}
