using TechPet.Domain.Abstractions.Entities;
using TechPet.Domain.ValueObjects.CnpjObject;

namespace TechPet.Domain.Entities.Empresas
{
    public class Empresa : Entity<Guid>
    {
        public const int TamanhoMaximoCodigo = 12;
        public const int TamanhoMaximoNome = 120;
        public const int TamanhoMaximoNomeFantasia = 60;

        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string NomeFantasia { get; private set; }
        public Cnpj Cnpj { get; private set; }

        public Empresa(string codigo, string nome, string nomeFantasia, string cnpj)
        {
            Codigo = codigo;
            Nome = nome;
            NomeFantasia = nomeFantasia;
            Cnpj = new Cnpj(cnpj);

            Validar();
        }

        protected Empresa()
        {
            Codigo = null!;
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
