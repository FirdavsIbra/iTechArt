using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IStudentsService
    {
        /// <summary>
        /// Imports students into DB from file
        /// </summary>
        public Task<IStudent[]> ImportStudentsAsync();

        /// <summary>
        /// Exports students from DB
        /// </summary>
        public Task<IStudent[]> ExportStudentsAsync();
    }
}
