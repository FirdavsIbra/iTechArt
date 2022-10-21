namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IStudentsService
    {
        /// <summary>
        /// Imports entities into DB from file
        /// </summary>
        public Task<List<string>> ImportStudentsAsync();
        /// <summary>
        /// Exports entities from DB
        /// </summary>
        public Task<List<string>> ExportStudentsAsync();

    }
}
