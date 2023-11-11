using Iowa.Domain.Common.Models;

namespace Iowa.Domain.Account.ValueObjects;

public sealed class AccountId : ValueObject {
    public Guid Id { get; }

    private AccountId(Guid id) {
        Id = id;
    }

    public static AccountId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Id;
    }
}