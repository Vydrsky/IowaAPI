
using Iowa.Application._Common.Exceptions.Base;
using Iowa.Application._Common.Interfaces.Services;
using Iowa.Domain.Common.Models;
using MediatR;

namespace Iowa.SqlServer.DataAccess.Extensions;

public class DomainEventPublisher : IDomainEventPublisher
{
    private readonly IPublisher _mediator;
    private readonly ApplicationDbContext _dbContext;

    public DomainEventPublisher(IPublisher mediator, ApplicationDbContext dbContext)
    {
        _mediator = mediator;
        _dbContext = dbContext;
    }

    public async Task PublishDomainEvents()
    {
        if (eventData.Context is null)
        {
            throw new DomainEventPublishException();
        }

        var entitiesWithDomainEvents = eventData.Context.ChangeTracker.Entries<IHasDomainEvents>()
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
