using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.Entities;
using Iowa.Domain.GameAggregate.ValueObjects;

namespace Iowa.SqlServer.DataAccess.Repositories;

public class GameRepository : GenericRepository<GameAggregate,GameId>,IGameRepository
{
    public async Task AddRoundToGameAsync(Guid gameId, Round round)
    {
        await Task.Run(() =>
        {
            _data.Where(game => game.Id.Value == gameId).Single().AddNewRound(round);
        });
    }

    public async Task RestartGame(Guid id)
    {
        await Task.Run(() =>
        {
            _data.Where(game => game.Id.Value == id).SingleOrDefault();
        });
    }
}
