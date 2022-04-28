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
        public async Task<ContentResult> GetUserActivitySummaryAsync(int id)
        {
            bool res = await _reportService.GetReportByUserIdAsync(id);
            var result = new ContentResult
            {
                Content = res.ToString(),
                ContentType = "application/json"
            };
            return result;
        }
    }
}