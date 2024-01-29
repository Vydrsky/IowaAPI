using Iowa.Domain.GameAggregate.Enums;

namespace Iowa.Contracts.Game.Requests;

public record AddNewRoundToGameRequest(
    Guid GameId,
    long PreviousBalance,
    CardRequest Card
);

public record CardRequest(
    CardType Type,
    long RewardValue,
    long PunishmentValueDefault,
    long PunishmentValueLower,
    long PunishmentValueUpper,
    short PunishmentPercentChance);