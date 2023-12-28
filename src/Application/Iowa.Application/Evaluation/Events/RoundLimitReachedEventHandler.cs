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
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoundLimitReachedEventHandler(IEvaluationRepository evaluationRepository, IUnitOfWork unitOfWork, IAccountRepository accountRepository)
    {
        _evaluationRepository = evaluationRepository;
        _unitOfWork = unitOfWork;
        _accountRepository = accountRepository;
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
        await _evaluationRepository.AddAsync(EvaluationAggregate.Create(notification.Game.UserId, notification.Game.AccountId, isPassed, DateTime.Now));
        await _unitOfWork.PublishNewDomainEvents();
    }
}
