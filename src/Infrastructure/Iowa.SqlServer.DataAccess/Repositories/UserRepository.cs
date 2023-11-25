using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.UserAggregate;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Infrastructure.Persistence;

public class UserRepository : IUserRepository {
    private List<User> users = new List<User>();

    public async Task AddUserAsync(User user) {
        await Task.Run(() => { 
            users.Add(user);
        });
    }

    public async Task<User?> GetUserByCodeAsync(string code) {
        return await Task.Run(() => {
            return users.Where(user => user.UserCode == code).FirstOrDefault();
            });
    }

    public async Task<User?> GetUserByIdAsync(UserId id) {
        return await Task.Run(() => {
            return users.Where(user => user.Id == id).FirstOrDefault();
        });
    }
}