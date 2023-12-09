namespace Iowa.Contracts.Account.Responses;

public record AccountResponse(
    long Balance,
    long PreviousBalance,
    Guid UserId,
    Guid GameId);