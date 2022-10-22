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

        public IGrocery[] ExportGrocery()
        {
            return _groceryRepository.GetAll();
        }

        public IGrocery[] ImportGrocery()
        {
            return _groceryRepository.GetAll();
        }
    }
}
