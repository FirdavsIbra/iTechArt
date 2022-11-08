using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IGroceryRepository
    {
        /// <summary>
        /// Get all groceries from database
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        Task<IGrocery[]> GetAllAsync();

        /// <summary>
        /// Get grocery by id
        /// </summary>
        /// <returns> Resopisitory model interface </returns>
        //Task<IGrocery> GetByIdAsync(long id);

        /// <summary>
        /// Update grocery
        /// </summary>
        Task UpdateAsync(IGrocery grocery);

        /// <summary>
        /// Delete grocery from database
        /// </summary>
        Task DeleteAsync(long id);

        /// </summary>
        /// Get count of groceries
        /// </summary>
        public ValueTask<int> GetCountOfGrocery();

        /// <summary>
        /// Add groceries to database
        /// </summary>
        public Task AddGroceriesAsync(IEnumerable<IGrocery> groceries);
    }
}
