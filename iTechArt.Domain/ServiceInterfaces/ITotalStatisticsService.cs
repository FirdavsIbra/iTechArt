using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface ITotalStatisticsService
    {
        public IDashboardInfo GetCountOfUsers();
    }
}
