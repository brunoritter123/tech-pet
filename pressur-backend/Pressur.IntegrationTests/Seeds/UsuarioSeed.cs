using Pressur.Data.Context;
using Pressur.Domain.Entities.Administracao;
using Pressur.Identity.Entities;
using Pressur.Identity.Interfaces;

namespace Pressur.IntegrationTests.Seeds
{
    public static class UsuarioSeed
    {
        public static async Task AddUsuarios(this PressurContext context, IIdentityService identityService)
        {
            var tasks = new List<Task<object>>();
            var userAdmin = new User()
            {
                Email = "brunosk8123@hotmail.com",
                Nome = "bruno",
                UserName = "brunosk8123@hotmail.com"
            };
            var userComum = new User()
            {
                Email = "comum@comum.com",
                Nome = "Comum",
                UserName = "comum@comum.com"
            };


            await context.Usuarios.AddAsync(new Usuario(userAdmin.UserName, userAdmin.Nome, userAdmin.Email));
            await context.Usuarios.AddAsync(new Usuario(userComum.UserName, userComum.Nome, userComum.Email));

            await identityService.CriarUsuarioAsync(userAdmin, "teste");
            await identityService.CriarUsuarioAsync(userComum, "teste");
        }
    }
}
