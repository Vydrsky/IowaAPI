using Iowa.Domain.GameAggregate.Enums;

namespace Iowa.Contracts.Game.Requests;

public record AddNewRoundToGameRequest(
    Guid GameId,
    long PreviousBalance,
    CardRequest Card
);

public record CardRequest(
    CardType CardType,
    long RewardValue,
    long PunishmentValue,
    short PunishmentPercentChance);