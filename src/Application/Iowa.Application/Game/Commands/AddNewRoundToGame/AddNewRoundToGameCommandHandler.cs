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

        var roundResult = await DecideResult(request);
        var total = await CalculateTotal(request, roundResult);
        short roundNumber = (short)(game.Rounds.Count + 1);

        var result = await _gameRepository.AddRoundToGameAsync(request.GameId, Round.Create(request.PreviousBalance, total, roundNumber, request.CardType, roundResult));

        await _unitOfWork.SaveChangesAsync();

        return new AddNewRoundResult(result);
    }

    private async Task<long> CalculateTotal(AddNewRoundToGameCommand request, bool roundResult)
    {
        var newTotal = request.PreviousBalance + request.RewardValue;
        if (roundResult) return newTotal;

        var rounds = await GetRoundsInCurrentGroup(request);

        var lostRounds = rounds.Where(r => !r.Won);

        var lowerLossRounds = (await GetRoundsInCurrentGroup(request))
            .Where(r => !r.Won && (r.Total - r.PreviousBalance == request.RewardValue - request.PunishmentValueLower));
        var upperLossRounds = (await GetRoundsInCurrentGroup(request))
          .Where(r => !r.Won && (r.Total - r.PreviousBalance == request.RewardValue - request.PunishmentValueUpper));

        //when lower and upper are unbalanced, choose the one missing
        if (lowerLossRounds.Count() > upperLossRounds.Count())
            return newTotal -= request.PunishmentValueUpper;

        else if(lowerLossRounds.Count() < upperLossRounds.Count())
            return newTotal -= request.PunishmentValueLower;

        //if there is only 1 slot left, return default
        if (lostRounds.Count() == (request.PunishmentPercentChance / 10) - 1)
            return newTotal -= request.PunishmentValueDefault;

        //when lower and upper are balanced, choose randomly
        return newTotal -= GetRandomPunishmentValue(request);
    }

    private async Task<bool> DecideResult(AddNewRoundToGameCommand request)
    {
        var rounds = await GetRoundsInCurrentGroup(request);
        var lostRounds = rounds.Where(r => !r.Won);

        //do not lose any more rounds in this bracket
        if (lostRounds.Count() >= (request.PunishmentPercentChance / 10))
        {
            return true;
        }

        //all rounds have to be lost if, theres exactly that many rounds remaining as rounds lost are missing
        if (10 - rounds.Count() == (request.PunishmentPercentChance / 10) - lostRounds.Count())
        {
            return false;
        }

        //win or lose with chance equal to given chance
        return RollForResult(request.PunishmentPercentChance);
    }

    private bool RollForResult(long baseChance)
    {
        Random rand = new Random(Guid.NewGuid().GetHashCode());
        return rand.Next(0, 10) >= (baseChance / 10);
    }

    private async Task<IEnumerable<Round>> GetRoundsInCurrentGroup(AddNewRoundToGameCommand request)
    {
        var roundsWithChosenCard = (await _gameRepository.GetByIdAsync(GameId.Create(request.GameId))).Rounds
            .Where(r => r.CardChosen == request.CardType)
            .OrderByDescending(r => r.RoundNumber);

        var currentGroup = roundsWithChosenCard.Count() % 10;

        return roundsWithChosenCard.Take(currentGroup);
    }

    private long GetRandomPunishmentValue(AddNewRoundToGameCommand request)
    {
        Random random = new Random(Guid.NewGuid().GetHashCode());
        switch (random.Next(0, 3))
        {
            case 1: return request.PunishmentValueLower;
            case 2: return request.PunishmentValueUpper;
            default: return request.PunishmentValueDefault;
        }
    }
}
