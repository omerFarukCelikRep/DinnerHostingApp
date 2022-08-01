using DinnerHostingApp.Application.Authentication.Common;
using DinnerHostingApp.Contracts.Authentication;
using Mapster;

namespace DinnerHostingApp.WebApi.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest, src => src.User);
    }
}