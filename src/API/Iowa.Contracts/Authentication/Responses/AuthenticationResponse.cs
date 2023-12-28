namespace Iowa.Contracts.Authentication.Responses;

public record AuthenticationResponse(
    Guid Id,
    string UserCode,
    bool IsAdmin,
    bool IsArchived,
    Guid AccountId,
    Guid GameId,
    string Token);