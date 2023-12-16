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
        return await Task.Run(() =>
        {
            return _dbSet.Where(x => x.Id == id).SingleOrDefault().EnsureExists();
        });
    }
    public async Task<IEnumerable<TAggregate>> GetAllAsync()
    {
        return await Task.Run(_dbSet.AsEnumerable);
    }

    public async Task AddAsync(TAggregate aggregate)
    {
        await Task.Run(() => _dbSet.Add(aggregate));
    }

    public async Task UpdateAsync(TAggregate aggregate)
    {
        await Task.Run(() =>
        {
            var result = _dbSet.Where(x => x.Id == aggregate.Id).SingleOrDefault().EnsureExists();

            result = aggregate;
        });
    }

    public async Task DeleteAsync(TId id)
    {
        await Task.Run(() =>
        {
            var result = _dbSet.Where(x => x.Id == id).SingleOrDefault().EnsureExists();

            _dbSet.Remove(result);
        });
    }

}
