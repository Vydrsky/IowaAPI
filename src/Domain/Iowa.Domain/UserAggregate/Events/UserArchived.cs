using Iowa.Domain.Common.Models;

namespace Iowa.Domain.UserAggregate.Events;

public record UserArchived(UserAggregate User) : IDomainEvent;