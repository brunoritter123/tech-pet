﻿using TechPet.Domain.Entities.Usuarios;
using TechPet.Domain.Entities.Usuarios.Commands.RegistrarUsuario;
using TechPet.UseCase.Abstractions;

namespace TechPet.UseCase.UseCases.Usuarios.Registrar
{
    public interface IRegistrarUsuarioUseCase : IUseCase<RegistrarUsuarioCommand, UsuarioResult?>
    {
    }
}
