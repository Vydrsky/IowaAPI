using Iowa.Domain.User;

namespace Iowa.Application.Interfaces.Persistence; 

public interface IUserRepository {
    Task<User?> GetUserByCodeAsync(string code);
    Task AddUserAsync(User user);
}