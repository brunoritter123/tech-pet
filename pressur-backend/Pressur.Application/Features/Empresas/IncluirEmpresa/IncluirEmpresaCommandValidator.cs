using FluentValidation;
using Pressur.Application.Abstractions.Extensions;
using Pressur.Domain.ValueObjects.CnpjObject;

namespace Pressur.Application.Features.Empresas.IncluirEmpresa;

public class IncluirEmpresaCommandValidator : AbstractValidator<IncluirEmpresaCommand>
{
    public IncluirEmpresaCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty();

        RuleFor(x => x.Cnpj)
            .NotEmpty()
            .TamanhoExato(Cnpj.TamanhoCnpj)
            .Matches("[0-9]+");
        
        RuleFor(x => x.Codigo)
            .NotEmpty();
        
        RuleFor(x => x.NomeFantasia)
            .NotEmpty();

        RuleForEach(x => x.Usuarios)
            .NotEmpty()
            .SetValidator(new IncluirEmpresaCommandUsuarioDtoValidator());
    }

    private class IncluirEmpresaCommandUsuarioDtoValidator : AbstractValidator<IncluirEmpresaCommand.UsuarioDto>
    {
        public IncluirEmpresaCommandUsuarioDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty();

            RuleFor(x => x.Senha)
                .NotEmpty();
        }
    }
}