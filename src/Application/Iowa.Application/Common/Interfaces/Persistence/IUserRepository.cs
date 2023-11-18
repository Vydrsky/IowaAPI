using Iowa.Domain.User;

namespace Iowa.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByCodeAsync(string code);
    Task AddUserAsync(User user);
}