
using Iowa.Domain.GameAggregate;

using MediatR;

namespace Iowa.Application.Game.Queries.GetGame;

public record GetGameQuery(Guid Id) : IRequest<GameAggregate>;
