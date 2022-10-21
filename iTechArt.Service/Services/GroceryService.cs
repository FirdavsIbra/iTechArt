using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Serivce.Services
{
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryService _groceryService;

        public GroceryService(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }
        /// <summary>
        /// Export grocery data
        /// </summary>
        public List<string> ExportGrocery()
        {
            return new List<string>();
        }
        /// <summary>
        /// Import grocery data
        /// </summary>
        public List<string> ImportGrocery()
        {
            return new List<string>();
        }
    }
}
