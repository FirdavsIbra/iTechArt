using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IGroceryRepository : IRepository<IGrocery>
    {
        /// <summary>
        /// Return Number Of Groceries
        /// </summary>
        public int GetCountOfGrocery();
    }
}
