using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate.Entities;

namespace Iowa.Domain.GameAggregate.Events;

public record RoundAdded(Round Round, AccountId AccountId) : IDomainEvent;
