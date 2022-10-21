using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPoliceService
    {
        /// <summary>
        /// function to imports data to the database
        /// </summary>
        public Task<List<string>> ImportPoliceData();

        /// <summary>
        /// function to exports data from the database
        /// </summary>
        public Task<List<IPolice>> ExportPoliceData();
    }
}
