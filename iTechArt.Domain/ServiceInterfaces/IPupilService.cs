using iTechArt.Database.Entities.Pupils;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPupilService
    {
        public IPupil[] ImportPupilsFile();
        public IPupil[] GetAllAsync();
        public Task<IPupil> GetByIdAsync(long id);
    }
}
