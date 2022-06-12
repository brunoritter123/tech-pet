using FluentValidation;

namespace TechPet.Domain.ValueObjects.CnpjObject
{
    public class CnpjValidador : AbstractValidator<Cnpj>
    {
        public CnpjValidador()
        {
            RuleFor(x => x.Valor)
               .Length(Cnpj.TamanhoCnpj)
               .WithMessage($"CNPJ deve conter {Cnpj.TamanhoCnpj} digitos.")
               .When(x => x.Valor != string.Empty)
               .Matches("[0-9]+")
               .WithMessage("CNPJ só pode conter números.");
        }
    }
}
