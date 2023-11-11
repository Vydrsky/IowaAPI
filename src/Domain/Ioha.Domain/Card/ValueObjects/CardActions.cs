using Iowa.Domain.Common.Models;

namespace Iowa.Domain.Card.ValueObjects;

public sealed class CardActions : ValueObject
{
    public long RewardValue { get; private set; }
    public long PunishmentValue { get; private set; }
    public short PunishmentPercentChance { get; private set; }

    private CardActions(long rewardValue, long punishmentValue, short punishmentPercentChance)
    {
        RewardValue = rewardValue;
        PunishmentValue = punishmentValue;
        PunishmentPercentChance = punishmentPercentChance;
    }

    public static CardActions Create(long rewardValue, long punishmentValue, short punishmentPercentChance)
    {
        return new(
            rewardValue,
            punishmentValue,
            punishmentPercentChance);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return RewardValue;
        yield return PunishmentValue;
        yield return PunishmentPercentChance;
    }
}