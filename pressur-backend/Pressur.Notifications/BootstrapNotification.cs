using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressur.Notifications.Filters;
using Pressur.Notifications.Services;

namespace Pressur.Notifications
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
