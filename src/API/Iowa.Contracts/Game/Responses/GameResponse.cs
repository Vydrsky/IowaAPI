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
    long Total,
    CardType Type);

public record CardResponse(
    CardType Type,
    long RewardValue,
    long PunishmentValueDefault,
    long PunishmentValueLower,
    long PunishmentValueUpper,
    short PunishmentPercentChance);