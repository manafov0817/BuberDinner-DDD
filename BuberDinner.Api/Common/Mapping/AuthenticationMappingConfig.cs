﻿using BuberDinner.Application.Authentication.Common;
using BuberDinner.Contracts.Authentitaction;
using Mapster;

namespace BuberDinner.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>();

        }
    }
}
