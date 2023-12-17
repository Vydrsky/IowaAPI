using Iowa.Domain.Common.Models;

namespace Iowa.Domain.GameAggregate.Events;

public record RoundAdded(GameAggregate Game) : IDomainEvent;
