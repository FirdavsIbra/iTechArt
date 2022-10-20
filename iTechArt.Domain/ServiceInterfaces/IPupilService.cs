using iTechArt.Database.Entities.Pupils;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPupilService
    {
        public List<string> ImportPupilsFile();
        public Task<List<Pupil>> ExportPupilsFileAsync();
    }
}
