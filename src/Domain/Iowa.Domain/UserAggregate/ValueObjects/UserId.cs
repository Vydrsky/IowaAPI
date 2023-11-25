using Iowa.Domain.Common.Models;

namespace Iowa.Domain.UserAggregate.ValueObjects;

public sealed class UserId : ValueObject {
    public Guid Id { get; }

    private UserId(Guid id) {
        Id = id;
    }

    public static UserId CreateUnique() => new(Guid.NewGuid());
    public static UserId Create(Guid id) => new(id);

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Id;
    }
}