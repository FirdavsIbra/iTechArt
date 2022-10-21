using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IAirportRepository : IRepository<IAirport>
    {
        /// </summary>
        /// Get count of airports
        /// </summary>
        /// <returns></returns>
        public int GetCountOfAirport();
    }
}
