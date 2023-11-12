using Iowa.Domain.Common.Models;
using Iowa.Domain.Game.Entities;
using Iowa.Domain.Game.ValueObjects;
using Iowa.Domain.User.ValueObjects;

namespace Iowa.Domain.Game;

public sealed class Game : AggregateRoot<GameId> {
    private readonly List<Round> _rounds = new();
    private readonly List<Card> _cards = new();
    public IReadOnlyList<Round> Rounds => _rounds.ToList().AsReadOnly();
    public IReadOnlyList<Card> CardIds => _cards.ToList().AsReadOnly();
    public UserId UserId { get; private set; }

    private Game(GameId id, UserId userId): base(id) {
        UserId = userId;
    }

    public static Game Create(UserId userId) {
        return new(
            GameId.CreateUnique(), 
            userId);
    }
}