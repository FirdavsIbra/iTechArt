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

        public Task<IPupil> GetByIdAsync(long id) => _pupilRepository.GetByIdAsync(id);
    }
}
