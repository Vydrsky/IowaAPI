using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.EvaluationAggregate.Events;

using MediatR;

namespace Iowa.Application.Game.Events;

public class EvaluationCreatedEventHandler : INotificationHandler<EvaluationCreated>
{
    private readonly IGameRepository _gameRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EvaluationCreatedEventHandler(IGameRepository gameRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(EvaluationCreated notification, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(notification.Evaluation.UserId);
        (await _gameRepository.GetByIdAsync(user.GameId)).EndGame();
        await _unitOfWork.PublishNewDomainEvents();
    }
}
