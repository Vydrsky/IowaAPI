using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.UserAggregate;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private List<UserAggregate> users = new List<UserAggregate>();

    public async Task AddUserAsync(UserAggregate user)
    {
        await Task.Run(() =>
        {
            users.Add(user);
        });
    }

    public async Task<UserAggregate?> GetUserByCodeAsync(string code)
    {
        return await Task.Run(() =>
        {
            return users.Where(user => user.UserCode == code).FirstOrDefault();
        });
    }

    public async Task<UserAggregate?> GetUserByIdAsync(UserId id)
    {
        return await Task.Run(() =>
        {
            return users.Where(user => user.Id == id).FirstOrDefault();
        });
    }
}