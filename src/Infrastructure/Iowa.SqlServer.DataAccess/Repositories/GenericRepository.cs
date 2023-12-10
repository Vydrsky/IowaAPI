using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application.Common.Exceptions;
using Iowa.Domain.Common.Models;

namespace Iowa.SqlServer.DataAccess.Repositories;

public class GenericRepository<TAggregate, TId> : IGenericRepository<TAggregate, TId> where TAggregate : AggregateRoot<TId> where TId : ValueObject
{
    protected List<TAggregate> _data = new();

    public async Task<TAggregate> GetByIdAsync(TId id)
    {
        return await Task.Run(() =>
        {
            var result = _data.Where(x => x.Id == id).SingleOrDefault();

            if (result is null)
            {
                throw new EntityNotFoundException();
            }

            return result;
        });
    }

    public async Task AddAsync(TAggregate aggregate)
    {
        await Task.Run(() =>_data.Add(aggregate));
    }

    public async Task UpdateAsync(TAggregate aggregate)
    {
        await Task.Run(() =>
        {
            var result = _data.Where(x => x.Id == aggregate.Id).SingleOrDefault();

            if (aggregate is null)
            {
                throw new EntityNotFoundException();
            }

            result = aggregate;
        });
    }

    public async Task DeleteAsync(TId id)
    {
        await Task.Run(() => {
            var result = _data.Where(x => x.Id == id).SingleOrDefault();

            if (result is null)
            {
                throw new EntityNotFoundException();
            }

            _data.Remove(result);
            });
    }
}
