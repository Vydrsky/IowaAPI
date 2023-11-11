using Iowa.Domain.Card.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.Game.ValueObjects;
using Iowa.Domain.Round.ValueObjects;
using Iowa.Domain.User.ValueObjects;

namespace Iowa.Domain.Game;

public sealed class Game : AggregateRoot<GameId> {
    private readonly List<RoundId> _rounds = new();
    private readonly List<CardId> _cards = new();
    public UserId UserId { get; }
    public IReadOnlyList<RoundId> RoundIds => _rounds.ToList().AsReadOnly();
    public IReadOnlyList<CardId> CardIds => _cards.ToList().AsReadOnly();

    private Game(GameId id, UserId userId): base(id) {
        UserId = userId;
    }

    public static Game Create(UserId userId) {
        return new(
            GameId.CreateUnique(), 
            userId);
    }
}