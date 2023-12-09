using Iowa.Domain.Common.Models;

namespace Iowa.Domain.GameAggregate.ValueObjects;

public sealed class GameId : ValueObject
{
    public Guid Value { get; }

    private GameId(Guid id)
    {
        Value = id;
    }

    public static GameId CreateUnique() => new(Guid.NewGuid());

    public static GameId Create(Guid id) => new(id);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}