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

        public async Task<List<Pupil>> ExportPupilsFileAsync()
        {
            return await _pupilRepository.GetAllAsync();
        }

        public List<string> ImportPupilsFile()
        {
            return new List<string>();
        }
    }
}
