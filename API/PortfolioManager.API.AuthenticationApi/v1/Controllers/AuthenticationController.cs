using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioManager.API.AuthenticationApi.v1.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioManager.API.AuthenticationApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Just mocking an Authentication process. 
        /// Only valid credentials are [username] & [password]
        /// </summary>
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login([Required] User user)
        {
            if (!user.UserName.Equals("username", StringComparison.InvariantCultureIgnoreCase) ||
                !user.Password.Equals("password"))
            {
                string errorMessage = $"Provided credentials not valid: username:{user.UserName} password:{user.Password}";
                _logger.LogWarning(errorMessage);
                return new BadRequestObjectResult(errorMessage);
            }

            return new CreatedAtRouteResult("login", true);
        }
    }
}
