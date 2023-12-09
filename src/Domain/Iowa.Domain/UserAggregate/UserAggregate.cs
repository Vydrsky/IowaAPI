using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Domain.UserAggregate;

public sealed class UserAggregate : AggregateRoot<UserId>
{
    public string UserCode { get; private set; }
    public AccountId AccountId { get; private set; }
    public GameId GameId { get; private set; }

    private UserAggregate(UserId id, string userCode, AccountId accountId, GameId gameId) : base(id)
    {
        UserCode = userCode;
        AccountId = accountId;
        GameId = gameId;
    }

    public static UserAggregate Create(string userCode, AccountId accountId, GameId gameId)
    {
        return new(
            UserId.CreateUnique(),
            userCode,
            accountId,
            gameId);
    }
}