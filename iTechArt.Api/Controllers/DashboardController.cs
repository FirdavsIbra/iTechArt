using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ITotalStatisticsService _statsService;

        public DashboardController(ITotalStatisticsService statsService)
        {
            _statsService = statsService;
        }

        /// <summary>
        /// returns total numbers of entities in db
        /// </summary>
        /// <returns>reurns IDictionary <string, int></string></returns>
        [HttpGet("total-amounts")]
        public IActionResult TotalAmounts()
        {
            return Ok(_statsService.GetTotalAmounts());
        }
    }
}
