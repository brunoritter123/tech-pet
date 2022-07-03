using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPet.Domain.Entities.Usuarios
{
    public class UsuarioValidador : AbstractValidator<Usuario>
    {
        public UsuarioValidador()
        {
            RuleFor(x => x.Login)
                .NotEmpty();

            RuleFor(x => x.Nome)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty();
        }
    }
}
