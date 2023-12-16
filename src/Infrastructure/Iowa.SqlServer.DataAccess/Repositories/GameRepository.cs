using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.Entities;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.SqlServer.DataAccess.Repositories.Base;

namespace Iowa.SqlServer.DataAccess.Repositories;

public class GameRepository : GenericSqlServerRepository<GameAggregate,GameId>,IGameRepository
{
    public GameRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task AddRoundToGameAsync(Guid gameId, Round round)
    {
        await Task.Run(() =>
        {
            var result = _dbContext.Games.Where(game => game.Id.Value == gameId).SingleOrDefault().EnsureExists();

            result.AddNewRound(round);
        });
    }

    public async Task RestartGame(Guid id)
    {
        await Task.Run(() =>
        {
            var result = _dbContext.Games.Where(game => game.Id.Value == id).SingleOrDefault().EnsureExists();

            result.CleanGameState();
        });
    }
}
