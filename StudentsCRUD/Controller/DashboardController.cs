using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var loggedInUsers = new List<User>(); // Implement logic to retrieve logged in users
            var allUsers = new List<User>(); // Implement logic to retrieve all users

            var onlineRegisteredUsers = loggedInUsers.Count;
            var offlineRegisteredUsers = allUsers.Count - onlineRegisteredUsers;

            var pieChartData = new List<PieChartItem>
            {
                new PieChartItem { Label = "Online Registered Users",
                    Value = onlineRegisteredUsers, Color = "blue" },
                new PieChartItem { Label = "Offline Registered Users",
                    Value = offlineRegisteredUsers, Color = "red" }
            };

            return Ok(new DashboardData { PieChartData = pieChartData });
        }
    }

    public class User
    {
        public string? Name { get; set; }
        public bool IsLoggedIn { get; set; }
    }

    public class DashboardData
    {
        public List<PieChartItem> PieChartData { get; set; }
    }

    public class PieChartItem
    {
        public string? Label { get; set; }
        public int Value { get; set; }
        public string? Color { get; set; }
    }
}
