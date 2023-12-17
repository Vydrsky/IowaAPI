using Iowa.Domain.Common.Models;

namespace Iowa.Domain.GameAggregate.Events;

public record RoundLimitReached(GameAggregate Game) : IDomainEvent;
