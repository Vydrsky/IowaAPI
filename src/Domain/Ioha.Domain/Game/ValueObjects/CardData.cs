using Iowa.Domain.Common.Models;

namespace Iowa.Domain.Game.ValueObjects;

public sealed class CardData : ValueObject {
    public long RewardValue { get; private set; }
    public long PunishmentValue { get; private set; }
    public short PunishmentPercentChance { get; private set; }

    private CardData(long rewardValue, long punishmentValue, short punishmentPercentChance) {
        RewardValue = rewardValue;
        PunishmentValue = punishmentValue;
        PunishmentPercentChance = punishmentPercentChance;
    }

    public static CardData Create(long rewardValue, long punishmentValue, short punishmentPercentChance) {
        return new(
            rewardValue, 
            punishmentValue, 
            punishmentPercentChance);
    }

    public override IEnumerable<object> GetEqualityComponents() {
        yield return RewardValue;
        yield return PunishmentValue;
        yield return PunishmentPercentChance;
    }
}