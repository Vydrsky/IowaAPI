using FluentValidation;

namespace Iowa.Application.Authentication.Commands.Authenticate;

public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand> {
    public AuthenticateCommandValidator() {
        RuleFor(x => x.UserCode)
            .NotEmpty()
            .MinimumLength(5)
            .NotNull();
    }
}