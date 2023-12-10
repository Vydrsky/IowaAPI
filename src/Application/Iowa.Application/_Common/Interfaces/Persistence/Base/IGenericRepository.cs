using Iowa.Domain.Common.Models;

namespace Iowa.Application._Common.Interfaces.Persistence.Base;

public interface IGenericRepository<TAggregate, TId> where TAggregate : AggregateRoot<TId> where TId : ValueObject
{
    Task<TAggregate> GetByIdAsync(TId id);
    Task<IEnumerable<TAggregate>> GetAllAsync();
    Task AddAsync(TAggregate aggregate);
    Task UpdateAsync(TAggregate aggregate);
    Task DeleteAsync(TId id);
}
