using Iowa.Domain.Common.Models;
using Iowa.Domain.Game.ValueObjects;

namespace Iowa.Domain.Game.Entities;

public sealed class Round : Entity<RoundId> {
    public short RoundNumber { get; private set; }
    public long PreviousBalance { get; private set; }
    public long Total { get; private set; }
    public GameId GameId { get; private set; }

    private Round(RoundId id, long previousBalance, long total, GameId gameID) : base(id) {
        GameId = gameID;
        PreviousBalance = previousBalance;
        Total = total;
    }

    public static Round Create(long previousBalance, long total, GameId gameId) {
        return new(
            RoundId.CreateUnique(),
            previousBalance,
            total,
            gameId);
    }
}