using FluentValidation;

namespace Iowa.Application.Game.Commands.RestartGame;

public class RestartGameCommandValidator : AbstractValidator<RestartGameCommand>
{
    public RestartGameCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
    }
}
