using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPoliceService
    {
        /// <summary>
        /// function to import data to the database
        /// </summary>
        public Task<IPolice[]> ImportPoliceData();

        /// <summary>
        /// function to export data from the database
        /// </summary>
        public Task<IPolice[]> ExportPoliceData();
    }
}
