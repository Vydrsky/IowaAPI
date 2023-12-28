using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate.Enums;
using Iowa.Domain.GameAggregate.Events;
using Iowa.Domain.GameAggregate.ValueObjects;

using MediatR;

namespace Iowa.Application.Game.Events;

public class GameCreatedEventHandler : INotificationHandler<GameCreated>
{
    private readonly IUnitOfWork _unitOfWork;

    public GameCreatedEventHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(GameCreated notification, CancellationToken cancellationToken)
    {
        var cards = new List<Card>
        {
            Card.Create(
                CardType.A,
                rewardValue: 100, 
                punishmentValueLower: 150,
                punishmentValueUpper: 350, 
                punishmentPercentChance: 50),
            Card.Create(
                CardType.B,
                rewardValue: 100,
                punishmentValueLower: 1250,
                punishmentValueUpper: 1250,
                punishmentPercentChance: 10),
            Card.Create(
                CardType.C,
                rewardValue: 50,
                punishmentValueLower: 25,
                punishmentValueUpper: 75,
                punishmentPercentChance: 50),
            Card.Create(
                CardType.D,
                rewardValue: 50,
                punishmentValueLower: 250,
                punishmentValueUpper: 250,
                punishmentPercentChance: 10),
        };

        cards.ForEach(notification.Game.AddNewCard);

        await _unitOfWork.PublishNewDomainEvents();
    }
}
