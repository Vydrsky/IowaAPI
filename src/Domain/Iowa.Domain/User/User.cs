using Iowa.Domain.Account.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.Game.ValueObjects;
using Iowa.Domain.User.ValueObjects;

namespace Iowa.Domain.User;

public sealed class User : AggregateRoot<UserId> {
    public string UserCode { get; private set; }
    public AccountId AccountId { get; private set; }
    public GameId GameId { get; private set; }

    private User(UserId id, string userCode, AccountId accountId, GameId gameId) : base(id) {
        UserCode = userCode;
        AccountId = accountId;
        GameId = gameId;
    }

    public static User Create(string userCode, AccountId accountId, GameId gameId) {
        return new(
            UserId.CreateUnique(),
            userCode,
            accountId,
            gameId);
    }
}