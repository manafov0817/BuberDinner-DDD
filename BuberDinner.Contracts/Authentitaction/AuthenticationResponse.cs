using BuberDinner.Domain.Entities;

namespace BuberDinner.Contracts.Authentitaction
{
    public record AuthenticationResponse(User user, string Token);
}
