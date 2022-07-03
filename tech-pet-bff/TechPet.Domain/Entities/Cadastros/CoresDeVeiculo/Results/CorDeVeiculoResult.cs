namespace TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Results
{
    public class CorDeVeiculoResult
    {
        public short Id { get; set; }
        public string Nome { get; set; }

        public CorDeVeiculoResult(short id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}