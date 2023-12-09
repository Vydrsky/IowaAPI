using Iowa.Application.Common.Exceptions;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.GameAggregate.Entities;

using MediatR;

namespace Iowa.Application.Game.Commands.AddNewRoundToGame;

public class AddNewRoundToGameCommandHandler : IRequestHandler<AddNewRoundToGameCommand>
{
    private readonly IGameRepository _gameRepository;

    public AddNewRoundToGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task Handle(AddNewRoundToGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetGameByIdAsync(request.GameId);
        if(game is null)
        {
            throw new EntityNotFoundException();
        }

        if (game.RoundLimitReached())
        {
            //event for creating evaluation

            //this will have to return some info for the client to end the game
            return;
        }

        var total = CalculateTotalByCard(request);
        await _gameRepository.AddRoundToGameAsync(request.GameId, Round.Create(request.PreviousBalance, total));

        //signal account to change
    }

    private long CalculateTotalByCard(AddNewRoundToGameCommand request)
    {
        Random rnd = new Random();
        var roll = rnd.Next(0, 100);
        return roll > request.PunishmentPercentChance
            ? request.PreviousBalance + request.RewardValue
            : request.PreviousBalance - request.PunishmentValue;
    }
}
