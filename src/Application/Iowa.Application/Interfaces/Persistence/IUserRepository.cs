using Iowa.Domain.User;
using Iowa.Domain.User.ValueObjects;

namespace Iowa.Application.Interfaces.Persistence; 

public interface IUserRepository {
    User? GetUserById(UserId id);
    void AddUser(User user);
}