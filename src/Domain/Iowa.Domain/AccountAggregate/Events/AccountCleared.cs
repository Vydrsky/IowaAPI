using Iowa.Domain.Common.Models;

namespace Iowa.Domain.AccountAggregate.Events;

public record AccountCleared(AccountAggregate Account) : IDomainEvent;
