using iTechArt.Database.Entities.Pupils;
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
        /// <returns></returns>
        public async Task<List<Pupil>> GetAllAsync()
        {
            return await _pupilRepository.GetAllAsync();
        }

        /// <summary>
        /// Import pupil's file
        /// </summary>
        /// <returns></returns>
        public List<string> ImportPupilsFile()
        {
            return new List<string>();
        }
    }
}
