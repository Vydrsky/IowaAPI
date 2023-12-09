using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.Entities;

namespace Iowa.Application.Common.Interfaces.Persistence;

public interface IGameRepository
{
    Task<GameAggregate?> GetGameByIdAsync(Guid id);
    Task AddGameAsync(GameAggregate game);
    Task AddRoundToGameAsync(Guid gameId, Round round);
    Task RestartGame(Guid id);
}
