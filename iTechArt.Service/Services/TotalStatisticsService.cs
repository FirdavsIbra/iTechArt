using iTechArt.Database.DbContexts;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public class TotalStatisticsService : ITotalStatisticsService
    {
        private readonly AppDbContext _dbContext;
        public TotalStatisticsService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDictionary<string, int> GetTotalAmounts()
        {
            Dictionary<string, int> totals = new Dictionary<string, int>();

            totals.Add("grocery", _dbContext.Groceries.Count());
            totals.Add("airport", _dbContext.Airports.Count());
            totals.Add("medStaff", _dbContext.Staffs.Count());
            totals.Add("pupils", _dbContext.Pupils.Count());
            totals.Add("police", _dbContext.Police.Count());
            totals.Add("students", _dbContext.Students.Count());

            return totals;
        }
    }
}
