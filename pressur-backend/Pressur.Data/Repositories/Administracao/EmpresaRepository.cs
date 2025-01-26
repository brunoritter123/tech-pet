using Pressur.Data.Abstractions;
using Pressur.Data.Context;
using Pressur.Domain.Abstractions.Repository;
using Pressur.Domain.Entities.Administracao;

namespace Pressur.Data.Repositories.Administracao
{
    public class EmpresaRepository : Repository<Empresa, Guid>, IEmpresaRepository
    {
        public EmpresaRepository(PressurContext dbContext)
            : base(dbContext)
        {
        }
    }
}