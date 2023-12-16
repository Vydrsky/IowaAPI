using Iowa.Domain.Common.Models;

namespace Iowa.Domain.GameAggregate.ValueObjects;

public sealed class RoundId : ValueObject
{
    public Guid Value { get; }

    private RoundId(Guid id)
    {
        Value = id;
    }

    public static RoundId CreateUnique() => new(Guid.NewGuid());

    public static RoundId Create(Guid id) => new(id);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private RoundId()
    {

    }
#pragma warning restore CS8618
}