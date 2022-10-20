using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPoliceRepository : IRepository<IPolice>
    {
        public int GetCountOfPolice();
    }
}
