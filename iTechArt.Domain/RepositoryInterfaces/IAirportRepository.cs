using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IAirportRepository : IRepository<IAirport>
    {
        /// <summary>
        /// Return Number Of Airports
        /// </summary>
        public int GetCountOfAirport();
    }
}
