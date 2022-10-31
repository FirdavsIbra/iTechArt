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
        IGrocery[] GetAll();

        /// <summary>
        /// Add grocery to database
        /// </summary>
        /// <param name="grocery"></param>
        Task AddAsync(IGrocery grocery);

        /// <summary>
        /// Get grocery by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resopisitory model interface </returns>
        //Task<IGrocery> GetByIdAsync(long id);

        /// <summary>
        /// Update grocery
        /// </summary>
        /// <param name="grocery"></param>
        Task UpdateAsync(IGrocery grocery);

        /// <summary>
        /// Delete grocery from database
        /// </summary>
        Task DeleteAsync(long id);

        /// </summary>
        /// Get count of groceries
        /// </summary>
        public int GetCountOfGrocery();

        public Task<IDbResult> AddGroceriesAsync(List<IGrocery> groceries);
    }
}
