using Iowa.Domain.Common.Models;

namespace Iowa.Application._Common.Interfaces.Services;

public interface IDomainEventPublisher
{
    Task PublishDomainEventsFromAggregate<TAggregate, TId>() where TAggregate : AggregateRoot<TId> where TId : ValueObject;
}
