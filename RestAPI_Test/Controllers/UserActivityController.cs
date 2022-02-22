using Microsoft.AspNetCore.Mvc;

namespace RestAPI_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserActivityController : ControllerBase
    {
        private readonly ILogger<UserActivityController> _logger;

        public UserActivityController(ILogger<UserActivityController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUserActivitySummary")]
        public void GetUserActivitySummary(int id)
        {

        }
    }
}