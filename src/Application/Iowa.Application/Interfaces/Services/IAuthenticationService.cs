using Iowa.Contracts.Requests;
using Iowa.Contracts.Responses;

namespace Iowa.Application.Interfaces.Services; 
public interface IAuthenticationService {
    public Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
}