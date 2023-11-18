using Iowa.Domain.User;

namespace Iowa.Application.Authentication.Results; 

public record AuthenticateResult(
    User user,
    string Token);