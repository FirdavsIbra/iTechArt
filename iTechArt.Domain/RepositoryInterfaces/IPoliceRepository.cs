using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPoliceRepository
    {
        /// <summary>
        /// Get all polices from database
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        IPolice[] GetAll();

        /// <summary>
        /// Add police to database
        /// </summary>
        /// <param name="police"></param>
        Task AddAsync(IPolice police);

        /// <summary>
        /// Get police by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resopisitory model interface </returns>
        Task<IPolice> GetByIdAsync(long id);

        /// <summary>
        /// Update police
        /// </summary>
        /// <param name="police"></param>
        Task UpdateAsync(IPolice police);

        /// <summary>
        /// Delete police from database
        /// </summary>
        Task DeleteAsync(long id);

        /// </summary>
        /// Get count of polices
        /// </summary>
        public int GetCountOfPolice();
    }
}
