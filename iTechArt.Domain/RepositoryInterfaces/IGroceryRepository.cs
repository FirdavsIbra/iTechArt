using iTechArt.Database.Entities.Groceries;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IGroceryRepository : IRepository<IGrocery, Grocery>
    {
        /// </summary>
        /// Get count of groceries
        /// </summary>
        public int GetCountOfGrocery();
    }
}
