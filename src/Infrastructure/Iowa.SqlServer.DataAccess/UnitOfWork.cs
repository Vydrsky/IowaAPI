using Iowa.Application._Common.Interfaces.Persistence.Base;

using Microsoft.EntityFrameworkCore;

namespace Iowa.SqlServer.DataAccess;

public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _dbContext;
    private readonly DomainEventPublisher _publisher;

    public UnitOfWork(TContext dbContext, DomainEventPublisher publisher)
    {
        _dbContext = dbContext;
        _publisher = publisher;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task PublishNewDomainEvents()
    {
        await _publisher.PublishDomainEvents(_dbContext);
    }
}
