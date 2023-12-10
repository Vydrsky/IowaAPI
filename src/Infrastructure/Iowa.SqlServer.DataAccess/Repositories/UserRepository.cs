using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.UserAggregate;
using Iowa.Domain.UserAggregate.ValueObjects;
using Iowa.SqlServer.DataAccess.Repositories;

namespace Iowa.Infrastructure.Persistence;

public class UserRepository : GenericRepository<UserAggregate,UserId>,IUserRepository
{
    public async Task<UserAggregate?> GetUserByCodeAsync(string code)
    {
        return await Task.Run(() =>
        {
            return _data.Where(user => user.UserCode == code).FirstOrDefault();
        });
    }
}