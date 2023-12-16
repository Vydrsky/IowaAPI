using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Domain.Common.Models;

namespace Iowa.SqlServer.DataAccess.Repositories.Base;

public class GenericSqlServerRepository<TAggregate, TId> : IGenericRepository<TAggregate, TId> where TAggregate : AggregateRoot<TId> where TId : ValueObject
{
    protected readonly ApplicationDbContext _dbContext;

    public GenericSqlServerRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<TAggregate> GetByIdAsync(TId id)
    {
        return await Task.Run(() =>
        {
            return _dbContext.Set<TAggregate>().Where(x => x.Id == id).SingleOrDefault().EnsureExists();
        });
    }
    public async Task<IEnumerable<TAggregate>> GetAllAsync()
    {
        return await Task.Run(_dbContext.Set<TAggregate>().AsEnumerable);
    }

    public async Task AddAsync(TAggregate aggregate)
    {
        await Task.Run(() => _dbContext.Set<TAggregate>().Add(aggregate));
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TAggregate aggregate)
    {
        await Task.Run(() =>
        {
            var result = _dbContext.Set<TAggregate>().Where(x => x.Id == aggregate.Id).SingleOrDefault().EnsureExists();

            result = aggregate;
        });
    }

    public async Task DeleteAsync(TId id)
    {
        await Task.Run(() =>
        {
            var result = _dbContext.Set<TAggregate>().Where(x => x.Id == id).SingleOrDefault().EnsureExists();

            _dbContext.Set<TAggregate>().Remove(result);
        });
    }

}
