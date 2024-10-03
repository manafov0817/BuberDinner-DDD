using BuberDinner.Api.Filters;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentitaction;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);


            return Ok(authResult);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var res = _authenticationService.Login(request.Email, request.Password);
            return Ok(res);
        }
    }
}
