using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IStudentsService
    {
        /// <summary>
        /// Imports entities into DB from file
        /// </summary>
        public IStudent[] ImportStudentsAsync();

        /// <summary>
        /// Exports entities from DB
        /// </summary>
        public IStudent[] ExportStudentsAsync();
    }
}
