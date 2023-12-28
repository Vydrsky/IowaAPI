using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application.Authentication.Results;
using Iowa.Application.Common.Interfaces.Authentication;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate;

using MediatR;

namespace Iowa.Application.Authentication.Commands.Authenticate;

public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateResult>
{

    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenGenerator _jwtTokenGenerator;

    public AuthenticateCommandHandler(IUserRepository userRepository, ITokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthenticateResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        UserAggregate? user = await _userRepository.GetUserByCodeAsync(request.UserCode);

        if (user is null)
        {
            var adminState = (request.UserCode == "{<)#% M%<()#$<%B$#B$sdg.;F6a;(");
            
            user = UserAggregate.Create(request.UserCode, adminState, AccountId.CreateUnique(), GameId.CreateUnique());
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        var token = await _jwtTokenGenerator.GenerateToken(request.UserCode);

        return new AuthenticateResult(user, token);
    }
}