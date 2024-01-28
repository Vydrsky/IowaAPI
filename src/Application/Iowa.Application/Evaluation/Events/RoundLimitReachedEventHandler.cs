using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate.Events;

using MediatR;
using Iowa.Domain.EvaluationAggregate;
using Iowa.Domain.GameAggregate.Enums;

namespace Iowa.Application.Evaluation.Events;

public class RoundLimitReachedEventHandler : INotificationHandler<RoundLimitReached>
{
    private readonly IEvaluationRepository _evaluationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoundLimitReachedEventHandler(IEvaluationRepository evaluationRepository, IUnitOfWork unitOfWork)
    {
        _evaluationRepository = evaluationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RoundLimitReached notification, CancellationToken cancellationToken)
    {
        var isPassed =
            notification.Game.Rounds
                .Where(r => r.CardChosen == CardType.C || r.CardChosen == CardType.D)
                .ToList().Count >
            notification.Game.Rounds
                .Where(r => r.CardChosen == CardType.A || r.CardChosen == CardType.B)
                .ToList().Count;

        if (!(await _evaluationRepository.GetAllAsync()).Where(e => e.UserId == notification.Game.UserId).Any()) { 
            await _evaluationRepository.AddAsync(EvaluationAggregate.Create(notification.Game.UserId, notification.Game.AccountId, isPassed, DateTime.Now));
        }

        await _unitOfWork.PublishNewDomainEvents();
    }
}
