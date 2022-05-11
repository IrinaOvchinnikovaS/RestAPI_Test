using Microsoft.AspNetCore.Mvc;
using RestAPI_Test.Services.Interfaces;

namespace RestAPI_Test.Controllers
{
    [Route("[controller]")]
    public class UserActivityController : Controller
    {
        private readonly ILogger<UserActivityController> _logger;

        private readonly IReportService _reportService;

        public UserActivityController(ILogger<UserActivityController> logger, IReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;
        }

        /// <summary>
        /// Forming report by user id
        /// </summary>
        [HttpGet("GetReport")]
        public async Task<ContentResult> GetReport(int id)
        {
            var res = await _reportService.GetReportByUserIdAsync(id);
            var result = new ContentResult
            {
                Content = res.ToString(),
                ContentType = "application/json"
            };
            return result;
        }
    }
}