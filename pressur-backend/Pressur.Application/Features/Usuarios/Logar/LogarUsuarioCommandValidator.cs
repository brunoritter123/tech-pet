using FluentValidation;

namespace Pressur.Application.Features.Usuarios.Logar;

public class LogarUsuarioCommandValidator : AbstractValidator<LogarUsuarioCommand>
{
    public LogarUsuarioCommandValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}