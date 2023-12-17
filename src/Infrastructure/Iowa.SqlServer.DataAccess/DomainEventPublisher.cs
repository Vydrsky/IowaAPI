using Iowa.Application._Common.Exceptions.Base;
using Iowa.Domain.Common.Models;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Iowa.SqlServer.DataAccess;

public class DomainEventPublisher
{
    private readonly IPublisher _mediator;

    public DomainEventPublisher(IPublisher mediator)
    {
        _mediator = mediator;
    }

    public async Task PublishDomainEvents(DbContext? context)
    {
        if (context is null)
        {
            throw new DomainEventPublishException();
        }

        var entitiesWithDomainEvents = context.ChangeTracker.Entries<IHasDomainEvents>()
            .Where(entry => entry.Entity.DomainEvents.Any())
            .Select(entry => entry.Entity)
            .ToList();

        var domainEvents = entitiesWithDomainEvents.SelectMany(e => e.DomainEvents).ToList();

        entitiesWithDomainEvents.ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent);
        }
    }
}
