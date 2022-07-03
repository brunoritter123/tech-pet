using TechPet.Domain.Abstractions.Entities;

namespace TechPet.Domain.Entities.Cadastros.CoresDeVeiculo
{
    public class CorDeVeiculo : Entity<short>
    {
        public const int TamanhoMaximoNome = 10;
        public string Nome { get; set; }

        public CorDeVeiculo(short id, string nome)
        {
            Id = id;
            Nome = nome;
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