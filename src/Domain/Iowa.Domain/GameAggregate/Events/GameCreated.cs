using Iowa.Domain.Common.Models;

namespace Iowa.Domain.GameAggregate.Events;

public record GameCreated(GameAggregate Game) : IDomainEvent;
