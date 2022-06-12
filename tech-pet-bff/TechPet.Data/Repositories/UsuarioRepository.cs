using Microsoft.EntityFrameworkCore;
using TechPet.Data.Abstractions;
using TechPet.Data.Context;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Usuarios;
using TechPet.Domain.Entities.Usuarios.Repository;

namespace TechPet.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario, Guid>, IUsuarioRepository
    {
        public UsuarioRepository(TechPetContext dbContext, INotificacaoService notificacaoService) : base(dbContext, notificacaoService)
        {
        }

        public async Task<Usuario?> BuscarPorLoginAsync(string login)
        {
            if (string.IsNullOrEmpty(login)) return null;
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => login.Equals(x.Login));
        }
    }
}
