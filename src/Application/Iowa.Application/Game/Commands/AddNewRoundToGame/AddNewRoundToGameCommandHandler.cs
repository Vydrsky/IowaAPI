using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Application.Game.Results;
using Iowa.Domain.GameAggregate.Entities;
using Iowa.Domain.GameAggregate.ValueObjects;

using MediatR;

namespace Iowa.Application.Game.Commands.AddNewRoundToGame;

public class AddNewRoundToGameCommandHandler : IRequestHandler<AddNewRoundToGameCommand, AddNewRoundResult>
{
    private readonly IGameRepository _gameRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddNewRoundToGameCommandHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AddNewRoundResult> Handle(AddNewRoundToGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByIdAsync(GameId.Create(request.GameId));

        var total = CalculateTotal(request);
        short roundNumber = (short)(game.Rounds.Count + 1);
        var result = await _gameRepository.AddRoundToGameAsync(request.GameId, Round.Create(request.PreviousBalance, total, roundNumber));

        await _unitOfWork.SaveChangesAsync();

        return new AddNewRoundResult(result);
    }

    private long CalculateTotal(AddNewRoundToGameCommand request)
    {
        var newTotal = request.PreviousBalance + request.RewardValue;
        Random rnd = new Random(Guid.NewGuid().GetHashCode());

        var rollForPunishment = rnd.Next(1, 101);
        if (rollForPunishment <= request.PunishmentPercentChance)
        {
            var punishmentValue = rnd.Next((int)request.PunishmentValueLower, (int)request.PunishmentValueUpper + 1);
            newTotal -= punishmentValue;
        }
        return newTotal;
    }
}
