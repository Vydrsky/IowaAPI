using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application.Common.Interfaces.Persistence;

using MediatR;

namespace Iowa.Application.Game.Commands.RestartGame;

public class RestartGameCommandHandler : IRequestHandler<RestartGameCommand>
{
    private readonly IGameRepository _gameRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RestartGameCommandHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RestartGameCommand request, CancellationToken cancellationToken)
    {
        await _gameRepository.RestartGame(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
