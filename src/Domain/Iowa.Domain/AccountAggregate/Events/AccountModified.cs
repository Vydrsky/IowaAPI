using Iowa.Domain.Common.Models;

namespace Iowa.Domain.AccountAggregate.Events;

public record AccountModified(AccountAggregate Account) : IDomainEvent;
