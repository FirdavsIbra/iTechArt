using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public sealed class PupilService : IPupilService
    {
        private readonly IPupilRepository _pupilRepository;

        public PupilService(IPupilRepository pupilRepository)
        {
            _pupilRepository = pupilRepository;
        }

        /// <summary>
        /// Get all pupils
        /// </summary>
        public IPupil[] GetAllAsync()
        {
            return _pupilRepository.GetAll();
        }

        /// <summary>
        /// Import pupil's file
        /// </summary>
        public IPupil[] ImportPupilsFile()
        {
            return _pupilRepository.GetAll();
        }

        /// <summary>
        /// Get pupil by id
        /// </summary>
        /// <param name="id"></param>
        public Task<IPupil> GetByIdAsync(long id) 
        { 
            return _pupilRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Add pupil to database
        /// </summary>
        /// <param name="pupil"></param>
        public async Task AddAsync(IPupil pupil)
        {
            await _pupilRepository.AddAsync(pupil);
        }

        /// <summary>
        /// Delete pupil
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteAsync(long id)
        {
            await _pupilRepository.DeleteAsync(id);
        }
    }
}
