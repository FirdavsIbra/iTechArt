namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IGroceryService
    {
        /// <summary>
        /// Import data for grocery
        /// </summary>
        public List<string> ImportGrocery();
        /// <summary>
        /// Export data for grocery
        /// </summary>
        public List<string> ExportGrocery();
    }
}
