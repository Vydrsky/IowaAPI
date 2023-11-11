using Iowa.Domain.Common.Models;

namespace Iowa.Domain.Account.ValueObjects;

public sealed class AccountId : ValueObject {
    public Guid Id { get; set; }

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Id;
    }
}