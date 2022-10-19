using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public sealed class PoliceService : IPoliceService
    {
        /// <summary>
        /// Export data from the databse
        /// </summary>
        public List<string> ExportPolice()
        {
            return new List<string>();
        }

        /// <summary>
        /// Import data to the database
        /// </summary>
        public List<string> ImportPolice()
        {
            return new List<string>();
        }
    }
}
