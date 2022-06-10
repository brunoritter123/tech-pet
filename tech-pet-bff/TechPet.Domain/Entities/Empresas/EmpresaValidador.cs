using FluentValidation;
using TechPet.Domain.ValueObjects.CnpjObject;

namespace TechPet.Domain.Entities.Empresas
{
    public class EmpresaValidador : AbstractValidator<Empresa>
    {
        public EmpresaValidador()
        {
            RuleFor(x => x.NomeFantasia)
                .NotEmpty();

            RuleFor(x => x.Nome)
                .NotEmpty();

            RuleFor(x => x.Cnpj)
                .NotNull()
                .SetValidator(new CnpjValidador());
        }
    }
}
