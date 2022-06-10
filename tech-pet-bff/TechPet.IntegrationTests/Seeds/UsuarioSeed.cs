using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Data.Context;
using TechPet.Domain.Entities.Usuarios;
using TechPet.Identity.Entities;
using TechPet.Identity.Interfaces;

namespace TechPet.IntegrationTests.Seeds
{
    public static class UsuarioSeed
    {
        public async static Task AddUsuarios(this TechPetContext context, IIdentityService identityService)
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
