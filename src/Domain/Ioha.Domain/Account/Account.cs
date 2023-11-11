using Iowa.Domain.Account.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.Game.ValueObjects;
using Iowa.Domain.User.ValueObjects;

namespace Iowa.Domain.Account;

public sealed class Account : AggregateRoot<AccountId> {
    public long Balance { get; }
    public long NetProfit { get; }
    public UserId UserId { get; }
    public GameId GameId { get; }

    private Account(AccountId id, long balance, long netProfit, UserId userId, GameId gameId) : base(id) {
        Balance = balance;
        NetProfit = netProfit;
        UserId = userId;
        GameId = gameId;
    }

    public static Account Create(long balance, long netProfit, UserId userId, GameId gameId) {
        return new(
            AccountId.CreateUnique(), 
            balance, 
            netProfit,
            userId,
            gameId);
    }
}