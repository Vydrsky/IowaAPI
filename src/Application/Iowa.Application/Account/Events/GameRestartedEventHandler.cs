using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Domain.GameAggregate.Events;

using MediatR;

namespace Iowa.Application.Account.Events;

public class GameRestartedEventHandler : INotificationHandler<GameRestarted>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GameRestartedEventHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(GameRestarted notification, CancellationToken cancellationToken)
    {
        await _accountRepository.CleanAccount(notification.Game.AccountId.Value);
        await _unitOfWork.PublishNewDomainEvents();
    }
}
