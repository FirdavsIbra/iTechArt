using iTechArt.Domain.ModelInterfaces;

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
        public Task AddUpdateAsync(IPolice police);

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
    }
}
