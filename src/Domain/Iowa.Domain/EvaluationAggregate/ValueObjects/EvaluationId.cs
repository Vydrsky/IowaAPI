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

#pragma warning disable CS8618
    private EvaluationId()
    {

    }
#pragma warning restore CS8618
}