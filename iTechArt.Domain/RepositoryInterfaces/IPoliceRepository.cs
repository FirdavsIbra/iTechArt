using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPoliceRepository : IRepository<IPolice>
    {
        /// <summary>
        /// Return Number Of Police Officers
        /// </summary>
        public int GetCountOfPolice();
    }
}
