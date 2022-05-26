using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Notifications.Filters;
using TechPet.Notifications.Services;

namespace TechPet.Notifications
{
    public static class BootstrapNotification
    {
        public static void AddBootstrapNotifications(this IServiceCollection service)
        {
            service.AddMvc(x =>
            {
                x.EnableEndpointRouting = false;
                x.Filters.Add<NotificationFilter>();
            });
            //.SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);

            service.AddScoped<INotificationService, NotificationService>;
        }
    }
}
