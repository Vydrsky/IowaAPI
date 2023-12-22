using Iowa.API.Controllers.Base;
using Iowa.Application.Authentication.Commands.Authenticate;
using Iowa.Application.Authentication.Results;
using Iowa.Contracts.Authentication.Requests;
using Iowa.Contracts.Authentication.Responses;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers;

[AllowAnonymous]
public class AuthController : IowaController
{

    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets or creates a user and returns a valid token
    /// </summary>
    [HttpPost(Name = "Authenticate")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<AuthenticationResponse>> Authenticate([FromBody] AuthenticateRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<AuthenticateRequest, AuthenticateCommand>(request));
        return Ok(_mapper.Map<AuthenticateResult, AuthenticationResponse>(result));
    }
}
