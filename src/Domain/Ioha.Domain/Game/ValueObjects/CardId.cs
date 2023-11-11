using Iowa.Domain.Common.Models;

namespace Iowa.Domain.Game.ValueObjects;

public sealed class CardId : ValueObject {
    public Guid Id { get; }

    private CardId(Guid id) {
        Id = id;
    }

    public static CardId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Id;
    }
}