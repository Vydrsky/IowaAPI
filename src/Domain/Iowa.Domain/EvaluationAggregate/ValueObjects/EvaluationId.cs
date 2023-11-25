using Iowa.Domain.Common.Models;

namespace Iowa.Domain.EvaluationAggregate.ValueObjects;

public sealed class EvaluationId : ValueObject {
    public Guid Id { get; }

    private EvaluationId(Guid id) {
        Id = id;
    }

    public static EvaluationId CreateUnique() => new(Guid.NewGuid());

    public static EvaluationId Create(Guid id) => new(id);

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Id;
    }
}