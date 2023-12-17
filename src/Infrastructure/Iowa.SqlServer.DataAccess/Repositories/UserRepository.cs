using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.UserAggregate;
using Iowa.Domain.UserAggregate.ValueObjects;
using Iowa.SqlServer.DataAccess;
using Iowa.SqlServer.DataAccess.Repositories.Base;

using Microsoft.EntityFrameworkCore;

namespace Iowa.Infrastructure.Persistence;

public class UserRepository : GenericSqlServerRepository<UserAggregate, UserId>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context.Users)
    {
    }

    public async Task<UserAggregate?> GetUserByCodeAsync(string code)
    {
        return await _dbSet.Where(user => user.UserCode == code).FirstOrDefaultAsync();
    }
}