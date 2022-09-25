using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo;

namespace TechPet.Data.Seeds
{
    public static class CorDeVeiculoSeed
    {
        public static IEnumerable<CorDeVeiculo> Gerar()
        {
            return new List<CorDeVeiculo>()
            {
                CorDeVeiculo.Create(1, "Prata"),
                CorDeVeiculo.Create(2, "Preto"),
                CorDeVeiculo.Create(3, "Vermelho"),
                CorDeVeiculo.Create(4, "Verde"),
                CorDeVeiculo.Create(5, "Laranja"),
                CorDeVeiculo.Create(6, "Azul"),
                CorDeVeiculo.Create(7, "Branco"),
                CorDeVeiculo.Create(8, "Cinza"),
                CorDeVeiculo.Create(9, "Marrom"),
                CorDeVeiculo.Create(10, "Bege"),
                CorDeVeiculo.Create(11, "Dourado"),
                CorDeVeiculo.Create(12, "Rosa"),
                CorDeVeiculo.Create(13, "Roxo"),
            };
        }
    }
}