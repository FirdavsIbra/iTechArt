using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IStudentsService
    {
        /// <summary>
        /// Imports students into DB from file
        /// </summary>
        public IStudent[] ImportStudentsAsync();

        /// <summary>
        /// Exports students from DB
        /// </summary>
        public IStudent[] ExportStudentsAsync();
    }
}
