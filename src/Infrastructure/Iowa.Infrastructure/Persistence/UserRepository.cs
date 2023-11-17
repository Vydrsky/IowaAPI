using Iowa.Application.Interfaces.Persistence;
using Iowa.Domain.User;
using Iowa.Domain.User.ValueObjects;

namespace Iowa.Infrastructure.Persistence;

public class UserRepository : IUserRepository {
    private List<User> users = new List<User>();

    public void AddUser(User user) {
        users.Add(user);
    }

    public User? GetUserById(UserId id) {
        return users.Where(user => user.Id == id).First();
    }
}