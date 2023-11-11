using Iowa.Domain.Common.Models;
using Iowa.Domain.Game.Enums;
using Iowa.Domain.Game.ValueObjects;

namespace Iowa.Domain.Game.Entities;

public sealed class Card : Entity<CardId> {
    public CardType Type { get; private set; }

    public CardData CardData { get; private set; }

    private Card(CardId id, CardType type, CardData cardData) : base(id) {
        Type = type;
        CardData = cardData;
    }

    public static Card Create(CardType type, CardData cardData) {
        return new(CardId.CreateUnique(), type, cardData);
    }

}