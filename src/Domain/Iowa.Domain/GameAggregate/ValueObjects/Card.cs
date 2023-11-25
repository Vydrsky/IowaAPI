using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate.Enums;

namespace Iowa.Domain.GameAggregate.ValueObjects;

public sealed class Card : ValueObject {
    public CardType Type { get; private set; }
    public long RewardValue { get; private set; }
    public long PunishmentValue { get; private set; }
    public short PunishmentPercentChance { get; private set; }
    public long Result { get; private set; }

    private Card(CardType type, long rewardValue, long punishmentValue, short punishmentPercentChance, long result) {
        Type = type;
        RewardValue = rewardValue;
        PunishmentValue = punishmentValue;
        PunishmentPercentChance = punishmentPercentChance;
        Result = result;
    }

    public static Card Create(CardType type, long rewardValue, long punishmentValue, short punishmentPercentChance, long result) {
        return new(type, rewardValue, punishmentValue, punishmentPercentChance, result);
    }

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Type;
        yield return RewardValue;
        yield return PunishmentValue;
        yield return PunishmentPercentChance;
        yield return Result;
    }
}