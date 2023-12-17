using Iowa.Domain.Common.Models;

namespace Iowa.Domain.GameAggregate.Events;

public record GameRestarted(GameAggregate Game) : IDomainEvent;
