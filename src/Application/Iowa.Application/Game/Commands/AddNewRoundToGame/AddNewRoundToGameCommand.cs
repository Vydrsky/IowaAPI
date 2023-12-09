using Iowa.Domain.GameAggregate.Enums;

using MediatR;

namespace Iowa.Application.Game.Commands.AddNewRoundToGame;

public record AddNewRoundToGameCommand(
    Guid GameId,
    long PreviousBalance,
    CardType CardType,
    long RewardValue,
    long PunishmentValue,
    short PunishmentPercentChance) : IRequest;