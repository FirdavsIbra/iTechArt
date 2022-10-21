using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IGroceryRepository : IRepository<IGrocery>
    {
        /// </summary>
        /// Get count of groceries
        /// </summary>
        /// <returns></returns>
        public int GetCountOfGrocery();
    }
}
