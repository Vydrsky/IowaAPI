using Iowa.API.Controllers.Base;
using Iowa.Application.Interfaces.Authentication;
using Iowa.Application.Interfaces.Services;
using Iowa.Contracts.Requests;
using Iowa.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers; 

public class AuthController : IowaController{

    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService) {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<ActionResult<AuthenticationResponse>> Authenticate(AuthenticationRequest request) {
        var response = await _authenticationService.Authenticate(request);
        return Ok(response);
    }
}
