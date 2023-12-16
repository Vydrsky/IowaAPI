using Iowa.Domain.Common.Models;

namespace Iowa.Domain.UserAggregate.Events;

public record UserCreated(UserAggregate User) : IDomainEvent;
