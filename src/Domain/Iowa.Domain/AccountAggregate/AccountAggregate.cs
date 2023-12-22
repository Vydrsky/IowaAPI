using Iowa.Domain.AccountAggregate.Events;
using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Domain.AccountAggregate;

public sealed class AccountAggregate : AggregateRoot<AccountId>
{
    public long Balance { get; private set; }
    public long PreviousBalance { get; private set; }
    public UserId UserId { get; private set; }
    public GameId GameId { get; private set; }

    private AccountAggregate(AccountId id, long balance, long previousBalance, UserId userId, GameId gameId) : base(id)
    {
        Balance = balance;
        PreviousBalance = previousBalance;
        UserId = userId;
        GameId = gameId;
    }

    public static AccountAggregate Create(long balance, long netProfit, UserId userId, GameId gameId, AccountId? id = null)
    {
        var account = new AccountAggregate(
            id ?? AccountId.CreateUnique(),
            balance,
            netProfit,
            userId,
            gameId);

        account.AddDomainEvent(new AccountCreated(account));

        return account;
    }

    public void ClearAccount()
    {
        Balance = 2000;
        PreviousBalance = Balance;
    }

    public void SetState(long newBalance)
    {
        PreviousBalance = Balance;
        Balance = newBalance;
    }

#pragma warning disable CS8618
    private AccountAggregate()
    {

    }
#pragma warning restore CS8618
}