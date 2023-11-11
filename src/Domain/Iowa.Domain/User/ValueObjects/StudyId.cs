using Iowa.Domain.Common.Models;

namespace Iowa.Domain.User.ValueObjects;

public sealed class StudyId : ValueObject {
    public Guid Id { get; }

    private StudyId(Guid id) {
        Id = id;
    }

    public static StudyId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Id;
    }
}