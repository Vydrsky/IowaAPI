using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Domain.UserAggregate;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IGenericRepository<UserAggregate, UserId>
{
    Task<UserAggregate?> GetUserByCodeAsync(string code);
}