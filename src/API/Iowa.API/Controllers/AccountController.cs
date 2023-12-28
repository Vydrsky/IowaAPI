using Iowa.API.Controllers.Base;
using Iowa.Application.Account.Queries.GetAccount;
using Iowa.Contracts.Account.Responses;
using Iowa.Domain.AccountAggregate;

using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers;

[Authorize]
public class AccountController : IowaController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AccountController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns an account by its id, if the account does not exist a new one is returned
    /// </summary>
    [HttpGet("{id}", Name = "GetAccount")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<AccountResponse>> GetAccount([FromRoute] Guid id) {
        var result = await _mediator.Send(new GetAccountQuery(id));
        return Ok(_mapper.Map<AccountAggregate, AccountResponse>(result));
    }
}
