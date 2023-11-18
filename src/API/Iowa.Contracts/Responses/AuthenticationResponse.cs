using Iowa.Domain.User;

namespace Iowa.Contracts.Responses;

public record AuthenticationResponse(
    User user,
    string Token);