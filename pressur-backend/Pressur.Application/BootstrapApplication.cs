using Microsoft.Extensions.DependencyInjection;
using Pressur.Application.Features.CoresDeVeiculo.ListarCoresDeVeiculo;
using Pressur.Application.Features.Empresas.IncluirEmpresa;
using Pressur.Application.Features.Usuarios.Logar;
using Pressur.Application.Features.Usuarios.Registrar;
using FluentValidation;

namespace Pressur.Application;

public static class BootstrapApplication
{
    public static IServiceCollection AddBootstrapUseCase(this IServiceCollection service)
    {
        service.AddScoped<IRegistrarUsuarioHandler, RegistrarUsuarioHandler>();
        service.AddScoped<IValidator<RegistrarUsuarioCommand>, RegistrarUsuarioCommandValidator>();
        
        service.AddScoped<ILogarUsuarioHandler, LogarUsuarioHandler>();
        service.AddScoped<IValidator<LogarUsuarioCommand>, LogarUsuarioCommandValidator>();
        
        service.AddScoped<IIncluirEmpresaHandler, IncluirEmpresaHandler>();
        service.AddScoped<IValidator<IncluirEmpresaCommand>, IncluirEmpresaCommandValidator>();
        
        service.AddScoped<IListarCoresDeVeiculoHandler, ListarCoresDeVeiculoHandler>();
        
        return service;
    }
}
