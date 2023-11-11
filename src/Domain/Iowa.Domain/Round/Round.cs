using Iowa.Domain.Account.ValueObjects;
using Iowa.Domain.Card.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.Game.ValueObjects;
using Iowa.Domain.Round.ValueObjects;

namespace Iowa.Domain.Round;

public sealed class Round : AggregateRoot<RoundId> {
    public short RoundNumber { get; }
    public RoundTransaction Transaction { get; }
    public CardId CardId { get; }
    public GameId GameId { get; }
    public AccountId AccountId { get; }

    private Round(RoundId id, RoundTransaction transaction, CardId cardId, GameId gameID, AccountId accountId) : base(id) {
        Transaction = transaction;
        CardId = cardId;
        GameId = gameID;
        AccountId = accountId;
    }

    public static Round Create(RoundTransaction transaction, CardId cardId, GameId gameId, AccountId accountId) {
        return new(
            RoundId.CreateUnique(), 
            transaction, 
            cardId, 
            gameId, 
            accountId);
    }
}