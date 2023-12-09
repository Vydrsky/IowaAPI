using Iowa.Domain.Common.Models;

namespace Iowa.Domain.EvaluationAggregate.ValueObjects;

public sealed class EvaluationId : ValueObject
{
    public Guid Value { get; }

    private EvaluationId(Guid id)
    {
        Value = id;
    }

    public static EvaluationId CreateUnique() => new(Guid.NewGuid());

    public static EvaluationId Create(Guid id) => new(id);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}