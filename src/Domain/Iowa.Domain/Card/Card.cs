using Iowa.Domain.Card.Enums;
using Iowa.Domain.Card.ValueObjects;
using Iowa.Domain.Common.Models;

namespace Iowa.Domain.Card;

public sealed class Card : AggregateRoot<CardId> {
    public CardType Type { get; private set; }
    public CardActions CardActions { get; private set; }
    public long Result { get; private set; }

    private Card(CardId id, CardType type, CardActions cardActions, long result) : base(id)
    {
        Type = type;
        CardActions = cardActions;
        Result = result;
    }

    public static Card Create(CardType type, CardActions cardActions, long result)
    {
        return new(CardId.CreateUnique(), type, cardActions, result);
    }

}