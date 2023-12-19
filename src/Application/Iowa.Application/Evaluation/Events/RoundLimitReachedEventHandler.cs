using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate.Events;

using MediatR;
using Iowa.Domain.EvaluationAggregate;

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
        var isPassed = (await _accountRepository.GetByIdAsync(notification.Game.AccountId)).Balance >= 4000;
        await _evaluationRepository.AddAsync(EvaluationAggregate.Create(notification.UserId, notification.Game.AccountId, isPassed, DateTime.Now));
        await _unitOfWork.PublishNewDomainEvents();
    }
}
