using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Application._Common.Interfaces.Services;
using Iowa.Domain.AccountAggregate;
using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.Events;
using Iowa.Domain.GameAggregate.ValueObjects;

using MediatR;

namespace Iowa.Application.Account.Events;

public class GameCreatedEventHandler : INotificationHandler<GameCreated>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IDomainEventPublisher _publisher;

    public GameCreatedEventHandler(IAccountRepository accountRepository, IDomainEventPublisher publisher)
    {
        _accountRepository = accountRepository;
        _publisher = publisher;
    }

    public async Task Handle(GameCreated notification, CancellationToken cancellationToken)
    {
        await _accountRepository.AddAsync(AccountAggregate.Create(2000, 0, notification.Game.UserId, notification.Game.Id, notification.Game.AccountId));
        await _publisher.PublishDomainEventsFromAggregate<AccountAggregate, AccountId>();
    }
}
