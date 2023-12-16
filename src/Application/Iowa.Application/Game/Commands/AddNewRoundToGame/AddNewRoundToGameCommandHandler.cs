using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate.Entities;
using Iowa.Domain.GameAggregate.ValueObjects;

using MediatR;

namespace Iowa.Application.Game.Commands.AddNewRoundToGame;

public class AddNewRoundToGameCommandHandler : IRequestHandler<AddNewRoundToGameCommand>
{
    private readonly IGameRepository _gameRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddNewRoundToGameCommandHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddNewRoundToGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByIdAsync(GameId.Create(request.GameId));

        if (game.RoundLimitReached())
        {
            //event for creating evaluation

            //this will have to return some info for the client to end the game
            return;
        }

        var total = CalculateTotal(request);
        await _gameRepository.AddRoundToGameAsync(request.GameId, Round.Create(request.PreviousBalance, total));
        await _unitOfWork.SaveChangesAsync();
    }

    private long CalculateTotal(AddNewRoundToGameCommand request)
    {
        Random rnd = new Random();
        var roll = rnd.Next(0, 100);
        return roll > request.PunishmentPercentChance
            ? request.PreviousBalance + request.RewardValue
            : request.PreviousBalance - request.PunishmentValue;
    }
}
