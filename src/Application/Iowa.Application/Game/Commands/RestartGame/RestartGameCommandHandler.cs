using Iowa.Application.Common.Interfaces.Persistence;

using MediatR;

namespace Iowa.Application.Game.Commands.RestartGame;

public class RestartGameCommandHandler : IRequestHandler<RestartGameCommand>
{
    private readonly IGameRepository _gameRepository;

    public RestartGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task Handle(RestartGameCommand request, CancellationToken cancellationToken)
    {
        await _gameRepository.RestartGame(request.Id);

        //event to restart account
    }
}
