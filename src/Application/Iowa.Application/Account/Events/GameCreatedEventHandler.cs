using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Domain.AccountAggregate;
using Iowa.Domain.GameAggregate.Events;

using MediatR;

namespace Iowa.Application.Account.Events;

public class GameCreatedEventHandler : INotificationHandler<GameCreated>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GameCreatedEventHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(GameCreated notification, CancellationToken cancellationToken)
    {
        await _accountRepository.AddAsync(AccountAggregate.Create(2000, 0, notification.Game.UserId, notification.Game.Id, notification.Game.AccountId));
        await _unitOfWork.PublishNewDomainEvents();
    }
}
