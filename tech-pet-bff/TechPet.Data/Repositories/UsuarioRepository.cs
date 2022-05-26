using Microsoft.EntityFrameworkCore;
using TechPet.Data.Abstractions;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Usuarios;
using TechPet.Domain.Entities.Usuarios.Repository;

namespace TechPet.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario, Guid>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext dbContext, INotificacaoService notificacaoService) : base(dbContext, notificacaoService)
        {
        }
    }
}
