using Microsoft.AspNetCore.Mvc;
using RestAPI_Test.Services.Interfaces;

namespace RestAPI_Test.Controllers
{
    public class UserActivityController : ControllerBase
    {
        private readonly ILogger<UserActivityController> _logger;

        private readonly IUsersService _usersService;

        public UserActivityController(ILogger<UserActivityController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [HttpGet]
        public async void GetUserActivitySummaryAsync(int id)
        {
            await _usersService.GetActivitySummaryAsync(id);
        }
    }
}