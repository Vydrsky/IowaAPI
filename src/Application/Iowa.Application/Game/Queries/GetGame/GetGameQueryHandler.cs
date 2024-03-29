﻿using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.ValueObjects;

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
        return await _gameRepository.GetByIdAsync(GameId.Create(request.Id));
    }
}
