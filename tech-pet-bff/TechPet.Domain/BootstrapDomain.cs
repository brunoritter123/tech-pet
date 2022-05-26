using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;
using TechPet.Domain.Abstractions.Notifications;

namespace TechPet.Domain
{
    public static class BootstrapDomain
    {
        public static IServiceCollection AddBootstrapDomain(this IServiceCollection service)
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            service.AddMediatR(Assembly.GetExecutingAssembly());

            service.AddScoped<INotificacaoService, NotificacaoService>();
            return service;
        }
    }
}
