using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Results;

namespace TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Mappers
{
    public static class CorDeVeiculoMapper
    {
        public static CorDeVeiculoResult ToCorDeVeiculoResult(this CorDeVeiculo entity)
            => new CorDeVeiculoResult(entity.Id, entity.Nome);
    }
}