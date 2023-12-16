using Iowa.Application._Common.Interfaces.Persistence.Base;

using Microsoft.EntityFrameworkCore;

namespace Iowa.SqlServer.DataAccess;

public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _dbContext;

    public UnitOfWork(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
