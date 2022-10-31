using iTechArt.Database.Entities.Groceries;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IGroceryRepository : IRepository<IGrocery, Grocery>
    {
        /// </summary>
        /// Get count of groceries
        /// </summary>
        public int GetCountOfGrocery();

        public Task<IDbResult> AddGroceriesAsync(List<IGrocery> groceries);
    }
}
