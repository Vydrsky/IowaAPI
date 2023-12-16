using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate.ValueObjects;

namespace Iowa.Domain.GameAggregate.Entities;

public sealed class Round : Entity<RoundId>
{
    public short RoundNumber { get; private set; }
    public long PreviousBalance { get; private set; }
    public long Total { get; private set; }

    private Round(RoundId id, long previousBalance, long total) : base(id)
    {
        PreviousBalance = previousBalance;
        Total = total;
    }

    public static Round Create(long previousBalance, long total)
    {
        return new(
            RoundId.CreateUnique(),
            previousBalance,
            total);
    }

#pragma warning disable CS8618
    private Round()
    {

    }
#pragma warning restore CS8618
}