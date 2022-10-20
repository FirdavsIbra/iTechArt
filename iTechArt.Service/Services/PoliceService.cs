using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public sealed class PoliceService : IPoliceService
    {
        /// <summary>
        /// Export data from the databse
        /// </summary>
        public List<string> ExportPoliceData()
        {
            return new List<string>();
        }

        /// <summary>
        /// Import data to the database
        /// </summary>
        public List<string> ImportPoliceData()
        {
            return new List<string>();
        }
    }
}
