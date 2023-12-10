using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.Entities;
using Iowa.Domain.GameAggregate.ValueObjects;

namespace Iowa.Application.Common.Interfaces.Persistence;

public interface IGameRepository : IGenericRepository<GameAggregate,GameId>
{
    Task AddRoundToGameAsync(Guid gameId, Round round);
    Task RestartGame(Guid id);
}
