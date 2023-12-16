using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Domain.AccountAggregate;
using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.SqlServer.DataAccess.Repositories.Base;

namespace Iowa.SqlServer.DataAccess.Repositories;

public class AccountRepository : GenericSqlServerRepository<AccountAggregate, AccountId>, IAccountRepository
{
    public AccountRepository(ApplicationDbContext context) : base(context.Accounts)
    {
    }
}
