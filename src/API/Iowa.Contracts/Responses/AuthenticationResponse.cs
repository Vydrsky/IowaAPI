
namespace Iowa.Contracts.Responses;

public record AuthenticationResponse(
    Guid Id,
    string UserCode,
    Guid AccountId,
    Guid GameId,
    string Token);