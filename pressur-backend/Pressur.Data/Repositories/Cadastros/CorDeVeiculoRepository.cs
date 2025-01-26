using Pressur.Data.Abstractions;
using Pressur.Data.Context;
using Pressur.Domain.Abstractions.Repository;
using Pressur.Domain.Entities.Cadastros;

namespace Pressur.Data.Repositories.Cadastros
{
    public class CorDeVeiculoRepository : ReadRepository<CorDeVeiculo, short>, ICorDeVeiculoRepository
    {
        public CorDeVeiculoRepository(PressurContext dbContext) : base(dbContext)
        {
        }
    }
}