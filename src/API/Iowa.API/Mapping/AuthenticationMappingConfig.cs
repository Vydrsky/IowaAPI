using Iowa.Application.Authentication.Commands.Authenticate;
using Iowa.Application.Authentication.Results;
using Iowa.Contracts.Requests;
using Iowa.Contracts.Responses;
using Mapster;

namespace Iowa.API.Mapping;

public class AuthenticationMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        config.NewConfig<AuthenticationRequest, AuthenticateCommand>()
            .TwoWays();

        config.NewConfig<AuthenticateResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User)
            .TwoWays();
    }
}
