using iTechArt.Database.Entities.Police;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPoliceRepository : IRepository<IPolice, Police>
    {
        /// </summary>
        /// Get count of polices
        /// </summary>
        /// <returns></returns>
        public int GetCountOfPolice();
    }
}
