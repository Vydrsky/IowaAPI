using Iowa.Domain.UserAggregate;

namespace Iowa.Application.Authentication.Results; 

public record AuthenticateResult(
    User User,
    string Token);