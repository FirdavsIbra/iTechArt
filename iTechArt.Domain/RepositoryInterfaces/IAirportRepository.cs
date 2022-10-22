using iTechArt.Database.Entities.Airports;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IAirportRepository : IRepository<IAirport, Airport>
    {
        /// </summary>
        /// Get count of airports
        /// </summary>
        /// <returns></returns>
        public int GetCountOfAirport();
    }
}
