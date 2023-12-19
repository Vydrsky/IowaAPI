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

        if (!game.RoundLimitReached())
        {
            var total = CalculateTotal(request);
            short roundNumber = (short)(game.Rounds.Count + 1);
            await _gameRepository.AddRoundToGameAsync(request.GameId, Round.Create(request.PreviousBalance, total, roundNumber));
        }

        await _unitOfWork.SaveChangesAsync();
    }

    private long CalculateTotal(AddNewRoundToGameCommand request)
    {
        var newTotal = request.PreviousBalance + request.RewardValue;
        Random rnd = new Random();

        var rollForPunishment = rnd.Next(1, 101);
        if (rollForPunishment <= request.PunishmentPercentChance) {
            var punishmentValue = rnd.Next((int)request.PunishmentValueLower, (int)request.PunishmentValueUpper + 1);
            newTotal -= punishmentValue;
        }
        return newTotal;
    }
}
