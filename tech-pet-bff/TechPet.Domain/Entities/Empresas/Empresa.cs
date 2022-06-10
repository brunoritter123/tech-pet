using TechPet.Domain.Abstractions.Entities;
using TechPet.Domain.ValueObjects.CnpjObject;

namespace TechPet.Domain.Entities.Empresas
{
    public class Empresa : Entity<Guid>
    {
        public string Nome { get; private set; }
        public string NomeFantasia { get; private set; }
        public Cnpj Cnpj { get; private set; }

        public Empresa(string nome, string nomeFantasia, string cnpj)
        {
            Nome = nome;
            NomeFantasia = nomeFantasia;
            Cnpj = new Cnpj(cnpj);

            Validar();
        }

        protected Empresa()
        {
            Nome = null!;
            NomeFantasia = null!;
            Cnpj = null!;
        }

        public override bool Validar()
            => OnValidate(this, new EmpresaValidador());

        public override NomeAmigavelDaEntitidade GetNomeDaEntitidadeAmigavel()
            => new NomeAmigavelDaEntitidade("a", "as", "empresa", "empresas");
    }
}
