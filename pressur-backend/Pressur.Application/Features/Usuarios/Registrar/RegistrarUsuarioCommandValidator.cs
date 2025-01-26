using FluentValidation;

namespace Pressur.Application.Features.Usuarios.Registrar;

public class RegistrarUsuarioCommandValidator : AbstractValidator<RegistrarUsuarioCommand>
{
    public RegistrarUsuarioCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty();
        
        RuleFor(x => x.Nome)
            .NotEmpty();
        
        RuleFor(x => x.Senha)
            .NotEmpty();
        
        RuleFor(x => x.Login)
            .NotEmpty();
    }
}
