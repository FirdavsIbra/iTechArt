namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IStudentsService
    {
        public List<string> ImportStudentsAsync();
        public Task<List<string>> ExportStudentsAsync();
        
    }
}
