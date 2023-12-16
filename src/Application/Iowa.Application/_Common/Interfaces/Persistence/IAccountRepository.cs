using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Domain.AccountAggregate;
using Iowa.Domain.AccountAggregate.ValueObjects;

namespace Iowa.Application._Common.Interfaces.Persistence;

public interface IAccountRepository : IGenericRepository<AccountAggregate, AccountId>
{
}
