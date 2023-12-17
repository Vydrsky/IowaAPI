using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Domain.Common.Models;

using Microsoft.EntityFrameworkCore;

namespace Iowa.SqlServer.DataAccess.Repositories.Base;

public class GenericSqlServerRepository<TAggregate, TId> : IGenericRepository<TAggregate, TId> where TAggregate : AggregateRoot<TId> where TId : ValueObject
{
    protected readonly DbSet<TAggregate> _dbSet;

    public GenericSqlServerRepository(DbSet<TAggregate> dbSet)
    {
        _dbSet = dbSet;
    }

    public async Task<TAggregate> GetByIdAsync(TId id)
    {
        var result = await _dbSet.Where(x => x.Id == id).SingleOrDefaultAsync();

        return result.EnsureExists();
    }
    public async Task<IEnumerable<TAggregate>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(TAggregate aggregate)
    {
        await _dbSet.AddAsync(aggregate);
    }

    public async Task UpdateAsync(TAggregate aggregate)
    {
        var result = await _dbSet.Where(x => x.Id == aggregate.Id).SingleOrDefaultAsync();

        result = aggregate.EnsureExists();
    }

    public async Task DeleteAsync(TId id)
    {
        var result = await _dbSet.Where(x => x.Id == id).SingleOrDefaultAsync();

        result = result.EnsureExists();

        _dbSet.Remove(result);
    }

}
