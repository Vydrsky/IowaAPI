using Iowa.Domain.Common.Models;

namespace Iowa.Domain.Round.ValueObjects;

public sealed class RoundTransaction : ValueObject {
    public long PreviousBalance { get; }
    public long Total { get; }

    private RoundTransaction(long previousBalance, long total) {
        PreviousBalance = previousBalance;
        Total = total;
    }

    public static RoundTransaction Create(long previousBalance, long total) {
        return new(previousBalance, total);
    }

    public override IEnumerable<object> GetEqualityComponents() {
        yield return PreviousBalance; 
        yield return Total;
    }
}