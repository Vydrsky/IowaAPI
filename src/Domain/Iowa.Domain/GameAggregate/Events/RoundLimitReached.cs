using Iowa.Domain.Common.Models;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Domain.GameAggregate.Events;

public record RoundLimitReached(GameAggregate Game, UserId UserId) : IDomainEvent;
