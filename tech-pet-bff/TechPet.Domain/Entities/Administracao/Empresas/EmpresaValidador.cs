using FluentValidation;
using TechPet.Domain.ValueObjects.CnpjObject;

namespace TechPet.Domain.Entities.Empresas
{
    public class EmpresaValidador : AbstractValidator<Empresa>
    {
        public EmpresaValidador()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty()
                .MaximumLength(Empresa.TamanhoMaximoCodigo)
                .Matches("[a-zA-Z0-9]+")
                .WithMessage("Código só pode conter letras e números");

            RuleFor(x => x.NomeFantasia)
                .NotEmpty()
                .MaximumLength(Empresa.TamanhoMaximoNomeFantasia);

            RuleFor(x => x.Nome)
                .NotEmpty()
                .MaximumLength(Empresa.TamanhoMaximoNome);

            RuleFor(x => x.Cnpj)
                .NotNull()
                .SetValidator(new CnpjValidador());
        }
    }
}
