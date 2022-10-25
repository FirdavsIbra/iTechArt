using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IAirportRepository
    {
        /// <summary>
        /// Get all airports from database
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        IAirport[] GetAll();

        /// <summary>
        /// Add airport to database
        /// </summary>
        /// <param name="airport"></param>
        Task AddAsync(IAirport airport);

        /// <summary>
        /// Get airport by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resopisitory model interface </returns>
        Task<IAirport> GetByIdAsync(long id);

        /// <summary>
        /// Update airport
        /// </summary>
        /// <param name="airport"></param>
        Task UpdateAsync(IAirport airport);

        /// <summary>
        /// Delete airport from database
        /// </summary>
        /// <param name="airport"></param>
        Task DeleteAsync(IAirport airport);

        /// </summary>
        /// Get count of airports
        /// </summary>
        public int GetCountOfAirport();
    }
}
