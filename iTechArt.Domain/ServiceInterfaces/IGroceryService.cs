using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IGroceryService
    {
        public IGrocery[] ImportGrocery();
        public IGrocery[] ExportGrocery();
    }
}
