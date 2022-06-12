using TechPet.Domain.Abstractions.ValueObject;

namespace TechPet.Domain.ValueObjects.CnpjObject
{
    public class Cnpj : ValueObject
    {
        public const int TamanhoCnpj = 14;
        public string Valor { get; private set; }

        public Cnpj(string valor = "")
        {
            Valor = valor;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Valor;
        }

        protected override string ValueObjectToString()
        {
            return Valor;
        }
    }
}
