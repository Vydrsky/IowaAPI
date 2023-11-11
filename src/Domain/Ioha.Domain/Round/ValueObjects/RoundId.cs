using Iowa.Domain.Common.Models;

namespace Iowa.Domain.Round.ValueObjects; 

public sealed class RoundId : ValueObject {
    public Guid Id { get; }

    private RoundId(Guid id) {
        Id = id;
    }

    public static RoundId CreateUnique() {
        return new RoundId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Id;
    }
}