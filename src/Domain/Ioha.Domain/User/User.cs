using Iowa.Domain.Account.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.Game.ValueObjects;
using Iowa.Domain.User.Entities;
using Iowa.Domain.User.ValueObjects;

namespace Iowa.Domain.User;

public sealed class User : AggregateRoot<UserId> {
    public string UserCode { get; }
    public Study Study { get; }
    public AccountId AccountId { get; }
    public GameId GameId { get; }

    private User(UserId id, string userCode, Study study, AccountId accountId, GameId gameId) : base(id) {
        UserCode = userCode;
        Study = study;
        AccountId = accountId;
        GameId = gameId;
    }

    public static User Create(string userCode, Study study, AccountId accountId, GameId gameId) {
        return new(
            UserId.CreateUnique(),
            userCode,
            study,
            accountId,
            gameId);
    }
}