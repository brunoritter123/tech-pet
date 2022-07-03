using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo;

namespace TechPet.Data.Seeds
{
    public static class CorDeVeiculoSeed
    {
        public static IEnumerable<CorDeVeiculo> Gerar()
        {
            return new List<CorDeVeiculo>()
            {
                new CorDeVeiculo(1, "Prata"),
                new CorDeVeiculo(2, "Preto"),
                new CorDeVeiculo(3, "Vermelho"),
                new CorDeVeiculo(4, "Verde"),
                new CorDeVeiculo(5, "Laranja"),
                new CorDeVeiculo(6, "Azul"),
                new CorDeVeiculo(7, "Branco"),
                new CorDeVeiculo(8, "Cinza"),
                new CorDeVeiculo(9, "Marrom"),
                new CorDeVeiculo(10, "Bege"),
                new CorDeVeiculo(11, "Dourado"),
                new CorDeVeiculo(12, "Rosa"),
                new CorDeVeiculo(13, "Roxo"),
            };
        }
    }
}