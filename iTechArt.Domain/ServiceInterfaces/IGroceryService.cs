namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IGroceryService
    {
        public List<string> ImportGrocery();
        public List<string> ExportGrocery();
    }
}
