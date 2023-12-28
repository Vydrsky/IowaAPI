using Iowa.API.Controllers.Base;
using Iowa.Application.Evaluation.Queries;
using Iowa.Contracts.Evaluation.Responses;
using Iowa.Domain.EvaluationAggregate;

using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers;

[Authorize]
public class EvaluationController : IowaController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public EvaluationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns a list of all evaluations
    /// </summary>
    [HttpGet(Name = "GetAllEvaluations")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IReadOnlyList<EvaluationResponse>>> GetAllEvaluations() {
        var result = await _mediator.Send(new GetAllEvaluationsQuery());
        return Ok(_mapper.Map<IEnumerable<EvaluationAggregate>, IEnumerable<EvaluationResponse>>(result));
    }
}
