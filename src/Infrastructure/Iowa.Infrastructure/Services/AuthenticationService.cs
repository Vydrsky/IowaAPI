using Iowa.Application.Interfaces.Authentication;
using Iowa.Application.Interfaces.Persistence;
using Iowa.Application.Interfaces.Services;
using Iowa.Contracts.Requests;
using Iowa.Contracts.Responses;
using Iowa.Domain.User;

namespace Iowa.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService {

    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest request) {
        if (_userRepository.GetUserById(request.UserId) is not null) {
            //restore state
            throw new Exception("User already exists");
        }

        //else create user
        var user = User.Create(request.UserCode, null, null);

        _userRepository.AddUser(user);

        var token = await _jwtTokenGenerator.GenerateToken(request.UserCode);

        return new AuthenticationResponse(user, token);
    }
}