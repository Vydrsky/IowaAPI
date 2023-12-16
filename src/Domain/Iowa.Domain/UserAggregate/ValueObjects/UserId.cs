using Iowa.Domain.Common.Models;

namespace Iowa.Domain.UserAggregate.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid id)
    {
        Value = id;
    }

    public static UserId CreateUnique() => new(Guid.NewGuid());
    public static UserId Create(Guid id) => new(id);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private UserId()
    {

    }
#pragma warning restore CS8618
}