using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate.Enums;

namespace Iowa.Domain.GameAggregate.ValueObjects;

public sealed class Card : ValueObject
{
    public CardType Type { get; private set; }
    public long RewardValue { get; private set; }
    public long PunishmentValueLower { get; private set; }
    public long PunishmentValueUpper { get; private set; }
    public short PunishmentPercentChance { get; private set; }

    private Card(CardType type, long rewardValue, long punishmentValueLower, long punishmentValueUpper, short punishmentPercentChance)
    {
        Type = type;
        RewardValue = rewardValue;
        PunishmentValueLower = punishmentValueLower;
        PunishmentValueUpper = punishmentValueUpper;
        PunishmentPercentChance = punishmentPercentChance;
    }

    public static Card Create(CardType type, long rewardValue, long punishmentValueLower, long punishmentValueUpper, short punishmentPercentChance)
    {
        return new(type, rewardValue, punishmentValueLower, punishmentValueUpper, punishmentPercentChance);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
        yield return RewardValue;
        yield return PunishmentValueLower;
        yield return PunishmentValueUpper;
        yield return PunishmentPercentChance;
    }

#pragma warning disable CS8618
    private Card()
    {

    }
#pragma warning restore CS8618
}