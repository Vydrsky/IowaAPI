using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate.Entities;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Domain.GameAggregate;

public sealed class GameAggregate : AggregateRoot<GameId>
{
    private readonly List<Round> _rounds = new();
    private readonly List<Card> _cards = new();
    public IReadOnlyList<Round> Rounds => _rounds.ToList().AsReadOnly();
    public IReadOnlyList<Card> Cards => _cards.ToList().AsReadOnly();
    public UserId UserId { get; private set; }
    public AccountId AccountId { get; private set; }

    private GameAggregate(GameId id, UserId userId, AccountId accountID) : base(id)
    {
        UserId = userId;
        AccountId = accountID;
    }

    public static GameAggregate Create(UserId userId, AccountId accountID)
    {
        return new(
            GameId.CreateUnique(),
            userId,
            accountID);
    }

    public void AddNewRound(Round round)
    {
        //Domain validation

        _rounds.Add(round);
    }

    public void CleanGameState()
    {
        _rounds.Clear();
    }

    public bool RoundLimitReached()
    {
        return _rounds.Count >= 100;
    }
}