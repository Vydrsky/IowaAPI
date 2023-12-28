using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.Events;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Domain.UserAggregate;

public sealed class UserAggregate : AggregateRoot<UserId>
{
    public string UserCode { get; private set; }
    public bool IsArchived { get; private set; }
    public bool IsAdmin { get; private set; }
    public AccountId AccountId { get; private set; }
    public GameId GameId { get; private set; }

    private UserAggregate(UserId id, bool isArchived, string userCode, bool isAdmin, AccountId accountId, GameId gameId) : base(id)
    {
        UserCode = userCode;
        AccountId = accountId;
        GameId = gameId;
        IsArchived = isArchived;
        IsAdmin = isAdmin;
    }

    public static UserAggregate Create(string userCode, bool isAdmin, AccountId accountId, GameId gameId, UserId? id = null)
    {
        var user = new UserAggregate(
            id ?? UserId.CreateUnique(),
            false,
            userCode,
            isAdmin,
            accountId,
            gameId);

        user.AddDomainEvent(new UserCreated(user));

        return user;
    }

    public void DisableUser()
    {
        IsArchived = true;
        AddDomainEvent(new UserArchived(this));
    }

#pragma warning disable CS8618
    private UserAggregate()
    {

    }
#pragma warning restore CS8618
}