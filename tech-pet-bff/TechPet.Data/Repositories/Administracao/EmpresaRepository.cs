using TechPet.Data.Abstractions;
using TechPet.Data.Context;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Empresas;
using TechPet.Domain.Entities.Empresas.Repository;

namespace TechPet.Data.Repositories
{
    public class EmpresaRepository : Repository<Empresa, Guid>, IEmpresaRepository
    {
        public EmpresaRepository(TechPetContext dbContext, INotificacaoService notificacaoService)
            : base(dbContext, notificacaoService)
        {
        }
    }
}