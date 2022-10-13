using iTechArt.Service.Interfaces;

namespace iTechArt.Service.Services
{
    public class PupilService : IPupilService
    {
        public IEnumerable<string> ExportPupilsFile()
        {
            return new List<string>();
        }

        public IEnumerable<string> ImportPupilsFile()
        {
            return new List<string>();
        }
    }
}
