using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.UserAggregate;
using Iowa.Domain.UserAggregate.ValueObjects;
using Iowa.SqlServer.DataAccess;
using Iowa.SqlServer.DataAccess.Repositories.Base;

namespace Iowa.Infrastructure.Persistence;

public class UserRepository : GenericSqlServerRepository<UserAggregate,UserId>,IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context.Users)
    {
    }

    public async Task<UserAggregate?> GetUserByCodeAsync(string code)
    {
        return await Task.Run(() =>
        {
            return _dbSet.Where(user => user.UserCode == code).FirstOrDefault();
        });
    }
}