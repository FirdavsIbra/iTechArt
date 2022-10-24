using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface ITotalStatisticsService
    {
        /// <summary>
        /// Get count of users
        /// </summary>
        public IDashboardInfo GetCountOfUsers();
    }
}
