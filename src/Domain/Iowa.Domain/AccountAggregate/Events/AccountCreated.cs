using Iowa.Domain.Common.Models;

namespace Iowa.Domain.AccountAggregate.Events;

public record AccountCreated(AccountAggregate Account) : IDomainEvent;
