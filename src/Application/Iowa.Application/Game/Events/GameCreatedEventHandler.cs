using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate.Events;

using MediatR;

namespace Iowa.Application.Game.Events;

public class GameCreatedEventHandler : INotificationHandler<GameCreated>
{
    private readonly IGameRepository _gameRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GameCreatedEventHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public Task Handle(GameCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
        //TODO
    }
}
