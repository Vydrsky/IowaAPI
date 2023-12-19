using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.Events;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Domain.UserAggregate;

public sealed class UserAggregate : AggregateRoot<UserId>
{
    public string UserCode { get; private set; }
    public bool IsActive { get; private set; }
    public AccountId AccountId { get; private set; }
    public GameId GameId { get; private set; }

    private UserAggregate(UserId id, bool isActive, string userCode, AccountId accountId, GameId gameId) : base(id)
    {
        UserCode = userCode;
        AccountId = accountId;
        GameId = gameId;
        IsActive = isActive;
    }

    public static UserAggregate Create(string userCode, AccountId accountId, GameId gameId, UserId? id = null)
    {
        var user = new UserAggregate(
            id ?? UserId.CreateUnique(),
            true,
            userCode,
            accountId,
            gameId);

        user.AddDomainEvent(new UserCreated(user));

        return user;
    }

    public void DisableUser()
    {
        IsActive = false;
        AddDomainEvent(new UserArchived(this));
    }

#pragma warning disable CS8618
    private UserAggregate()
    {

    }
#pragma warning restore CS8618
}