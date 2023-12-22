using System.Net.Mime;

using Iowa.API.Controllers.Base;
using Iowa.Application.Game.Commands.AddNewRoundToGame;
using Iowa.Application.Game.Commands.RestartGame;
using Iowa.Application.Game.Queries.GetGame;
using Iowa.Application.Game.Results;
using Iowa.Contracts.Game.Requests;
using Iowa.Contracts.Game.Responses;
using Iowa.Domain.GameAggregate;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers;

public class GameController : IowaController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;


    public GameController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns a game for the user, or creates a new one if it did not exist
    /// </summary>
    [HttpGet("{id}", Name = "GetGame")]
    [ProducesResponseType(200)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GameResponse>> GetGame([FromRoute] Guid id) {
        var result = await _mediator.Send(new GetGameQuery(id));
        return Ok(_mapper.Map<GameAggregate, GameResponse>(result));
    }

    /// <summary>
    /// Adds new round to the game. This invokes many domain events that control the flow of the game forwards
    /// </summary>
    [HttpPost(Name = "AddNewRoundToGame")]
    [ProducesResponseType(200)]
    public async Task<ActionResult> AddNewRoundToGame([FromBody] AddNewRoundToGameRequest request) {
        var result = await _mediator.Send(_mapper.Map<AddNewRoundToGameRequest, AddNewRoundToGameCommand>(request));
        return Ok(_mapper.Map<AddNewRoundResult,AddNewRoundResponse>(result));
    }

    /// <summary>
    /// Restores game to initial state
    /// </summary>
    [HttpPut("{id}", Name = "RestartGame")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<GameResponse>> RestartGame([FromRoute] Guid id) {
        await _mediator.Send(new RestartGameCommand(id));
        return Ok();
    }
}
