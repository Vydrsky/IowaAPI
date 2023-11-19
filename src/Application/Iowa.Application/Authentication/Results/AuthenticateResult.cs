using Iowa.Domain.User;

namespace Iowa.Application.Authentication.Results; 

public record AuthenticateResult(
    User User,
    string Token);