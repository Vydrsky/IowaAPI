using Iowa.Application.Common.Exceptions;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate;

using MediatR;

namespace Iowa.Application.Game.Queries.GetGame;

public class GetGameQueryHandler : IRequestHandler<GetGameQuery, GameAggregate>
{
    private readonly IGameRepository _gameRepository;

    public GetGameQueryHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<GameAggregate> Handle(GetGameQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetGameByIdAsync(request.Id);

        return game is null ? throw new EntityNotFoundException() : game;
    }
}
