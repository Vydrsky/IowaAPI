using Iowa.API.Controllers.Base;
using Iowa.Application.Common.Exceptions;
using Iowa.Application.User.Queries.GetUser;
using Iowa.Contracts.User.Responses;
using Iowa.Domain.UserAggregate;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers;

public class UserController : IowaController
{

    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public UserController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns only an existing user.
    /// </summary>
    [HttpGet("{id}", Name = "GetUser")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<UserResponse>> GetUser([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetUserQuery(id));

        return Ok(_mapper.Map<UserAggregate, UserResponse>(result));
    }
}
