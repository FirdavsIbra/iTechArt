using iTechArt.Database.Entities.Pupils;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPupilRepository : IRepository<Pupil>
    {
        public int GetCountOfPupils();
    }
}
