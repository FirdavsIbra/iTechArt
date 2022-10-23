using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Serivce.Services
{
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository _groceryRepository;
        public GroceryService(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

        /// <summary>
        /// Export grocery data
        /// </summary>
        public IGrocery[] ExportGrocery()
        {
            return _groceryRepository.GetAll();
        }
        
        /// <summary>
        /// Import grocery data
        /// </summary>
        public IGrocery[] ImportGrocery()
        {
            return _groceryRepository.GetAll();
        }
    }
}
