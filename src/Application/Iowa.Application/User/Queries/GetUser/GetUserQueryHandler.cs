using Iowa.Application.Common.Exceptions;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.UserAggregate;
using Iowa.Domain.UserAggregate.ValueObjects;

using MediatR;

namespace Iowa.Application.User.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserAggregate>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserAggregate> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(UserId.Create(request.Id));

        return user is null ? throw new EntityNotFoundException() : user;
    }
}
