using Iowa.Domain.User.ValueObjects;

namespace Iowa.Contracts.Requests;

public record AuthenticationRequest(
    UserId UserId,
    string UserCode);