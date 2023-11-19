using Iowa.Application.Authentication.Results;
using Iowa.Application.Common.Exceptions;
using Iowa.Application.Common.Interfaces.Authentication;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.Account.ValueObjects;
using Iowa.Domain.Game.ValueObjects;
using Iowa.Domain.User;
using MediatR;

namespace Iowa.Application.Authentication.Commands.Authenticate;

public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateResult>
{

    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _jwtTokenGenerator;

    public AuthenticateCommandHandler(IUserRepository userRepository, ITokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticateResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        throw new SampleException();
        User? user = await _userRepository.GetUserByCodeAsync(request.UserCode);

        if (user is null)
        {
            user = User.Create(request.UserCode, AccountId.CreateUnique(), GameId.CreateUnique());
            await _userRepository.AddUserAsync(user);
        }

        var token = await _jwtTokenGenerator.GenerateToken(request.UserCode);

        return new AuthenticateResult(user, token);
    }
}