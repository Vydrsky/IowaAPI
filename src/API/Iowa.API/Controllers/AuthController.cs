using Iowa.API.Controllers.Base;
using Iowa.Application.Authentication.Commands.Authenticate;
using Iowa.Application.Authentication.Results;
using Iowa.Contracts.Requests;
using Iowa.Contracts.Responses;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers;

[AllowAnonymous]
public class AuthController : IowaController{

    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper) {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<AuthenticationResponse>> Authenticate(AuthenticationRequest request) {
        var result = await _mediator.Send(_mapper.Map<AuthenticationRequest, AuthenticateCommand>(request));
        return Ok(_mapper.Map<AuthenticateResult, AuthenticationResponse>(result));
    }
}
