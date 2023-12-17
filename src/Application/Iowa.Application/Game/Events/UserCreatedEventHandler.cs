using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.Events;

using MediatR;

namespace Iowa.Application.Game.Events;

public class UserCreatedEventHandler : INotificationHandler<UserCreated>
{
    private readonly IGameRepository _gameRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserCreatedEventHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
        await _gameRepository.AddAsync(GameAggregate.Create(notification.User.Id, notification.User.AccountId, GameId.Create(notification.User.GameId.Value)));
        await _unitOfWork.PublishNewDomainEvents();
    }
}
