using Iowa.Domain.User.ValueObjects;

namespace Iowa.Contracts.Requests;

public record AuthenticationRequest(
    string UserCode);