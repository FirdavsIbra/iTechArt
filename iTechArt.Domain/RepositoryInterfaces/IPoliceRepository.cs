using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPoliceRepository
    {
        /// <summary>
        /// Get all polices from database
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        public Task<IPolice[]> GetAllAsync();

        /// <summary>
        /// Add police to database
        /// </summary>
        /// <param name="police"></param>
        public Task AddAsync(IPolice police);

        /// <summary>
        /// Get police by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resopisitory model interface </returns>
        public Task<IPolice> GetByIdAsync(long id);

        /// <summary>
        /// Delete police from database
        /// </summary>
        public Task DeleteAsync(long id);

        /// </summary>
        /// Get count of polices
        /// </summary>
        public int GetCountOfPolice();


        /// <summary>
        /// Updates entity in the database
        /// </summary>
        /// <param name="police"></param>
        /// <returns></returns>
        public Task UpdateAsync(IPolice police);

        /// <summary>
        /// Adds collection of entities to the database
        /// </summary>
        /// <param name="police"></param>
        /// <returns></returns>
        public Task AddRangeAsync(List<IPolice> police);
    }
}
