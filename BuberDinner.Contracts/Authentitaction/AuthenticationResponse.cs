using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Contracts.Authentitaction
{
    public record AuthenticationResponse(User user, string Token);
}
