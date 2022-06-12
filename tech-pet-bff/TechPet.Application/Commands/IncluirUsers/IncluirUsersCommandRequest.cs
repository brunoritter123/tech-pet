using Microsoft.Extensions.Logging;
using TechPet.Application.Extensions.Identity.NotifyIdentityErrors;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Identity.Entities;
using TechPet.Identity.Interfaces;

namespace TechPet.Application.Commands.IncluirUsers
{
    public class IncluirUsersCommandRequest
    {
        public User User { get; set; }
        public string Senha { get; set; }

        public IncluirUsersCommandRequest(User user, string senha)
        {
            User = user;
            Senha = senha;
        }
    }
}
