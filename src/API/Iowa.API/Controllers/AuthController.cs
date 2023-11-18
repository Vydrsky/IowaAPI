using Iowa.API.Controllers.Base;
using Iowa.Application.Authentication.Commands.Authenticate;
using Iowa.Contracts.Requests;
using Iowa.Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers;

public class AuthController : IowaController{

    private readonly ISender _mediator;

    public AuthController(ISender mediator) {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<AuthenticationResponse>> Authenticate(AuthenticationRequest request) {
        var command = new AuthenticateCommand(request.UserCode);
        var response = await _mediator.Send(command);

        return Ok(response);
    }
}
