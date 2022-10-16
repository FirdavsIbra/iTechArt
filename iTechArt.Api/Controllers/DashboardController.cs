using iTechArt.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ITotalStatisticsService _statsService;

        public DashboardController(ITotalStatisticsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet("total-amounts")]
        public IActionResult TotalAmounts()
        {
            return Ok(_statsService.GetTotalAmounts());
        }
    }
}
