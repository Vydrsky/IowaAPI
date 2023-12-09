using MediatR;

namespace Iowa.Application.Game.Commands.RestartGame;

public record RestartGameCommand(Guid Id) : IRequest;