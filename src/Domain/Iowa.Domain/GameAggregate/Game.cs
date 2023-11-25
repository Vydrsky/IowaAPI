using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate.Entities;
using Iowa.Domain.UserAggregate.ValueObjects;
using Iowa.Domain.GameAggregate.ValueObjects;

namespace Iowa.Domain.GameAggregate;

public sealed class Game : AggregateRoot<GameId> {
    private readonly List<Round> _rounds = new();
    private readonly List<Card> _cards = new();
    public IReadOnlyList<Round> Rounds => _rounds.ToList().AsReadOnly();
    public IReadOnlyList<Card> Cards => _cards.ToList().AsReadOnly();
    public UserId UserId { get; private set; }
    public AccountId AccountId { get; private set; }

    private Game(GameId id, UserId userId, AccountId accountID): base(id) {
        UserId = userId;
        AccountId = accountID;
    }

    public static Game Create(UserId userId, AccountId accountID) {
        return new(
            GameId.CreateUnique(), 
            userId,
            accountID);
    }
}