namespace iTechArt.Domain.ServiceInterfaces
{
    public interface ITotalStatisticsService
    {
        public IDictionary<string, int> GetTotalAmounts();
    }
}
