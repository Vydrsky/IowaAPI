using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Domain.GameAggregate.Events;

using MediatR;

namespace Iowa.Application.Account.Events;

public class RoundAddedEventHandler : INotificationHandler<RoundAdded>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoundAddedEventHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RoundAdded notification, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetByIdAsync(notification.AccountId);

        account.SetState(notification.Round.Total);

        await _unitOfWork.PublishNewDomainEvents();
    }
}