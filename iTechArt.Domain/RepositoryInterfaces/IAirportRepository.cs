using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IAirportRepository : IRepository<IAirport>
    {
        public int GetCountOfAirport();
    }
}
