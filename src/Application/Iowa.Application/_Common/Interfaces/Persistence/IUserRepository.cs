using Iowa.Domain.UserAggregate;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<UserAggregate?> GetUserByCodeAsync(string code);
    Task<UserAggregate?> GetUserByIdAsync(UserId id);
    Task AddUserAsync(UserAggregate user);
}