using TechPet.Domain.Abstractions.Entities;

namespace TechPet.Domain.Entities.Cadastros.CoresDeVeiculo
{
    public class CorDeVeiculo : Entity<short>
    {
        public const int TamanhoMaximoNome = 10;
        public string Nome { get; private set; }

        public CorDeVeiculo(string nome)
        {
            Nome = nome;
        }

        public static CorDeVeiculo Create(short id, string nome)
        {
            var cor = new CorDeVeiculo(nome);
            cor.Id = id;
            return cor;
        }

        public override NomeAmigavelDaEntitidade GetNomeDaEntitidadeAmigavel()
        {
            return new NomeAmigavelDaEntitidade("da", "das", "cor", "cores");
        }

        public override bool Validar()
        {
            return OnValidate(this, new CorDeVeiculoValidator());
        }
    }
}