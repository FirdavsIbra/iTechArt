using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPoliceRepository : IRepository<IPolice>
    {
        /// <summary>
        /// Get count of polices
        /// </summary>
        /// <returns></returns>
        public int GetCountOfPolice();
    }
}
