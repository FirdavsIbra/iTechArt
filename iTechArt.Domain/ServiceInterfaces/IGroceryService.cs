using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IGroceryService
    {
        /// <summary>
        /// Import data for grocery
        /// </summary>
        public IGrocery[] ImportGrocery();

        /// <summary>
        /// Export data for grocery
        /// </summary>
        public IGrocery[] ExportGrocery();
    }
}
