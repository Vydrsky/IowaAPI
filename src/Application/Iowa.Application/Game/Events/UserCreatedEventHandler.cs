using Iowa.Application._Common.Interfaces.Services;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.Events;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.Events;

using MediatR;

namespace Iowa.Application.Game.Events;

public class UserCreatedEventHandler : INotificationHandler<UserCreated>
{
    private readonly IGameRepository _gameRepository;
    private readonly IDomainEventPublisher _publisher;

    public UserCreatedEventHandler(IGameRepository gameRepository, IDomainEventPublisher publisher)
    {
        _gameRepository = gameRepository;
        _publisher = publisher;
    }

    public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
        await _gameRepository.AddAsync(GameAggregate.Create(notification.User.Id, notification.User.AccountId, GameId.Create(notification.User.GameId.Value)));
        await _publisher.PublishDomainEventsFromAggregate<GameAggregate,GameId>();
    }
}
