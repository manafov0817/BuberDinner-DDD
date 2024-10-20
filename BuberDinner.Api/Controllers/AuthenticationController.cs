using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Login;
using BuberDinner.Application.Authentication.Register;
using BuberDinner.Contracts.Authentitaction;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [AllowAnonymous]
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                error => Problem(error));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var command = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                            error => Problem(error));
        }       
    }
}
