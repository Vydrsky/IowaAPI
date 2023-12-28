namespace Iowa.Contracts.User.Responses;

public record UserResponse(
    Guid Id,
    string UserCode,
    bool IsAdmin,
    bool IsArchived,
    Guid AccountId,
    Guid GameId);