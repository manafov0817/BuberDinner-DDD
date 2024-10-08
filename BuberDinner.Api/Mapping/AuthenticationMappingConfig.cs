using BuberDinner.Application.Authentication.Common;
using BuberDinner.Contracts.Authentitaction;
using Mapster;

namespace BuberDinner.Api.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>();

        }
    }
}
