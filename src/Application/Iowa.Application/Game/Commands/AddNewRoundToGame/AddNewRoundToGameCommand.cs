using Iowa.Domain.GameAggregate.Enums;

using MediatR;

namespace Iowa.Application.Game.Commands.AddNewRoundToGame;

public record AddNewRoundToGameCommand(
    Guid GameId,
    long PreviousBalance,
    CardType CardType,
    long RewardValue,
    long PunishmentValueLower,
    long PunishmentValueUpper,
    short PunishmentPercentChance) : IRequest;