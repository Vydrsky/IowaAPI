using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Domain.Account;
using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.SqlServer.DataAccess.Repositories.Base;

namespace Iowa.SqlServer.DataAccess.Repositories;

public class AccountRepository : GenericRepository<AccountAggregate, AccountId>, IAccountRepository
{
}
