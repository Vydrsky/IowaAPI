using Iowa.Application.Authentication.Results;

using MediatR;

namespace Iowa.Application.Authentication.Commands.Authenticate;
public record AuthenticateCommand(
    string UserCode) : IRequest<AuthenticateResult>;