using Pressur.Domain.Abstractions.Entities;
using Pressur.Domain.ValueObjects.CnpjObject;

namespace Pressur.Domain.Entities.Administracao
{
    public class Empresa : Entity<Guid>
    {
        public const int TamanhoMaximoCodigo = 12;
        public const int TamanhoMaximoNome = 120;
        public const int TamanhoMaximoNomeFantasia = 60;

        public string Nome { get; private set; }
        public string NomeFantasia { get; private set; }
        public Cnpj Cnpj { get; private set; }

        public Empresa(string codigoEmpresa, string nome, string nomeFantasia, string cnpj)
        {
            CodigoEmpresa = codigoEmpresa;
            Nome = nome;
            NomeFantasia = nomeFantasia;
            Cnpj = new Cnpj(cnpj);
        }

        protected Empresa()
        {
            CodigoEmpresa = null!;
            Nome = null!;
            NomeFantasia = null!;
            Cnpj = null!;
        }
    }
}
