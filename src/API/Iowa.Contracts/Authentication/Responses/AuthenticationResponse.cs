namespace Iowa.Contracts.Authentication.Responses;

public record AuthenticationResponse(
    Guid Id,
    string UserCode,
    Guid AccountId,
    Guid GameId,
    string Token);