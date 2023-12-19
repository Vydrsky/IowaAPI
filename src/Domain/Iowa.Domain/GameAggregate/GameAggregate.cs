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
    public bool IsActive { get; private set; }
    public UserId UserId { get; private set; }
    public AccountId AccountId { get; private set; }

    private GameAggregate(GameId id, bool isActive, UserId userId, AccountId accountID) : base(id)
    {
        UserId = userId;
        AccountId = accountID;
        IsActive = isActive;
    }

    public static GameAggregate Create(UserId userId, AccountId accountID, GameId? id = null)
    {
        var game = new GameAggregate(
            id ?? GameId.CreateUnique(),
            true,
            userId,
            accountID);

        game.AddDomainEvent(new GameCreated(game));

        return game;
    }

    public void AddNewRound(Round round)
    {
        _rounds.Add(round);
        AddDomainEvent(new RoundAdded(round, AccountId));
    }

    public void AddNewCard(Card card)
    {
        _cards.Add(card);
    }

    public void CleanGameState()
    {
        _rounds.Clear();
        AddDomainEvent(new GameRestarted(this));
    }

    public bool RoundLimitReached()
    {
        if (_rounds.Count >= 10)
        {
            AddDomainEvent(new RoundLimitReached(this, UserId));
            return true;
        }
        return false;
    }

    public void EndGame()
    {
        IsActive = false;
        AddDomainEvent(new GameEnded(this));
    }

#pragma warning disable CS8618
    private GameAggregate()
    {

    }
#pragma warning restore CS8618
}