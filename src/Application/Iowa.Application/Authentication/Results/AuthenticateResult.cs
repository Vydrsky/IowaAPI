using Iowa.Domain.UserAggregate;

namespace Iowa.Application.Authentication.Results;

public record AuthenticateResult(
    UserAggregate User,
    string Token);