using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.Entities;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.SqlServer.DataAccess.Repositories.Base;

using Microsoft.EntityFrameworkCore;

namespace Iowa.SqlServer.DataAccess.Repositories;

public class GameRepository : GenericSqlServerRepository<GameAggregate, GameId>, IGameRepository
{
    public GameRepository(ApplicationDbContext context) : base(context.Games)
    {
    }

    public async Task AddRoundToGameAsync(Guid gameId, Round round)
    {
        var result = await _dbSet.Where(game => game.Id == GameId.Create(gameId)).SingleOrDefaultAsync();

        result.EnsureExists().AddNewRound(round);
    }

    public async Task RestartGame(Guid id)
    {
        var result = await _dbSet.Where(game => game.Id == GameId.Create(id)).SingleOrDefaultAsync();
            
        result.EnsureExists().CleanGameState();
    }
}
