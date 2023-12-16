using Iowa.Domain.Common.Models;

namespace Iowa.Domain.AccountAggregate.ValueObjects;

public sealed class AccountId : ValueObject
{
    public Guid Value { get; }

    private AccountId(Guid id)
    {
        Value = id;
    }

    public static AccountId CreateUnique() => new(Guid.NewGuid());

    public static AccountId Create(Guid id) => new(id);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private AccountId()
    {

    }
#pragma warning restore CS8618
}