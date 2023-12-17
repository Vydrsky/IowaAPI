using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate.Entities;
using Iowa.Domain.GameAggregate.Events;
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

    public static GameAggregate Create(UserId userId, AccountId accountID, GameId? id = null)
    {
        var game = new GameAggregate(
            id ?? GameId.CreateUnique(),
            userId,
            accountID);

        game.AddDomainEvent(new GameCreated(game));

        return game;
    }

    public void AddNewRound(Round round)
    {
        _rounds.Add(round);
        AddDomainEvent(new RoundAdded(this));
    }

    public void CleanGameState()
    {
        _rounds.Clear();
        AddDomainEvent(new GameRestarted(this));
    }

    public bool RoundLimitReached()
    {
        if (_rounds.Count >= 100)
        {
            AddDomainEvent(new RoundLimitReached(this));
            return true;
        }
        return false;
    }

#pragma warning disable CS8618
    private GameAggregate()
    {

    }
#pragma warning restore CS8618
}