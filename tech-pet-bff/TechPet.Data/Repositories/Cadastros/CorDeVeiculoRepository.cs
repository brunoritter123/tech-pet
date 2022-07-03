using TechPet.Data.Abstractions;
using TechPet.Data.Context;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Repository;

namespace TechPet.Data.Repositories.Cadastros
{
    public class CorDeVeiculoRepository : ReadRepository<CorDeVeiculo, short>, ICorDeVeiculoRepository
    {
        public CorDeVeiculoRepository(TechPetContext dbContext) : base(dbContext)
        {
        }
    }
}