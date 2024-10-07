using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Login
{
    public record LoginQuery(string Email,
                                  string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
