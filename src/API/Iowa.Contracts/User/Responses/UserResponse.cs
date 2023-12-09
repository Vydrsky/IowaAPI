namespace Iowa.Contracts.User.Responses;

public record UserResponse(
    Guid Id,
    string UserCode,
    Guid AccountId,
    Guid GameId);