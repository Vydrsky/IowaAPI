using Iowa.Domain.GameAggregate.Enums;

namespace Iowa.Contracts.Game.Responses;

public record GameResponse(
    Guid Id,
    IReadOnlyList<RoundResponse> Rounds,
    IReadOnlyList<CardResponse> Cards,
    Guid UserId,
    Guid AccountId);

public record RoundResponse(
    Guid Id,
    short RoundNumber,
    long PreviousBalance,
    long Total);

public record CardResponse(
    CardType Type,
    long RewardValue,
    long PunishmentValue,
    short PunishmentPercentChance,
    long Result);