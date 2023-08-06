using BuberDinner.Application.Authentication.Common;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(authResponse => authResponse.Token, authResult => authResult.Token)
            .Map(authResponse => authResponse, authResult => authResult.User);
    }
}