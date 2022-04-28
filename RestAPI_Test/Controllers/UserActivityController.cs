using Microsoft.AspNetCore.Mvc;
using RestAPI_Test.Services.Interfaces;

namespace RestAPI_Test.Controllers
{
    public class UserActivityController : ControllerBase
    {
        private readonly ILogger<UserActivityController> _logger;

        private readonly IReportService _reportService;

        public UserActivityController(ILogger<UserActivityController> logger, IReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;
        }

        [HttpGet]
        public async void GetUserActivitySummaryAsync(int id)
        {
            bool result = await _reportService.GetReportByUserIdAsync(id);
        }
    }
}