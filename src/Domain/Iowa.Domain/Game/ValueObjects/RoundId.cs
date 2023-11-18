using Iowa.Domain.Common.Models;

namespace Iowa.Domain.Game.ValueObjects;

public sealed class RoundId : ValueObject {
    public Guid Id { get; }

    private RoundId(Guid id) {
        Id = id;
    }

    public static RoundId CreateUnique() => new(Guid.NewGuid());

    public static RoundId Create(Guid id) => new(id);

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Id;
    }
}