using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.Entities;

namespace Iowa.SqlServer.DataAccess.Repositories;

public class GameRepository : IGameRepository
{
    private List<GameAggregate> _games = new List<GameAggregate>();

    public async Task<GameAggregate?> GetGameByIdAsync(Guid id)
    {
        return await Task.Run(() => _games.Where(game => game.Id.Value == id).FirstOrDefault());
    }
    
    public async Task AddGameAsync(GameAggregate game)
    {
        await Task.Run(() => _games.Add(game));
    }

    public async Task AddRoundToGameAsync(Guid gameId, Round round)
    {
        await Task.Run(() =>
        {
            _games.Where(game => game.Id.Value == gameId).Single().AddNewRound(round);
        });
    }

    public async Task RestartGame(Guid id)
    {
        await Task.Run(() =>
        {
            _games.Where(game => game.Id.Value == id).SingleOrDefault().;
        });
    }
}
