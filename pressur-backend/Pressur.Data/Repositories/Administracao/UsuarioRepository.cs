using Microsoft.EntityFrameworkCore;
using Pressur.Data.Abstractions;
using Pressur.Data.Context;
using Pressur.Domain.Abstractions.Repository;
using Pressur.Domain.Entities.Administracao;

namespace Pressur.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario, Guid>, IUsuarioRepository
    {
        public UsuarioRepository(PressurContext dbContext) : base(dbContext)
        {
        }

        public async Task<Usuario?> BuscarPorLoginAsync(string login)
        {
            if (string.IsNullOrEmpty(login)) return null;
            return await DbSet.AsNoTracking().SingleOrDefaultAsync(x => login.Equals(x.Login));
        }
    }
}