using Iowa.Application.Common.Exceptions;

using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Iowa.SqlServer.DataAccess.Interceptors;

public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly DomainEventPublisher _publisher;

    public PublishDomainEventsInterceptor(DomainEventPublisher publisher)
    {
        _publisher = publisher;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        throw new SynchronousDatabaseOperationException();
    }

    public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await _publisher.PublishDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

}
