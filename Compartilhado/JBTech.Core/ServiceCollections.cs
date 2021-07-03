using JBTech.Core.Notifications;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Core
{
    public static class ServiceCollections
    {
        public static IServiceCollection RegistrarDependenciasDominioCore(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler, NotificationHandler>();

            return services;
        }
    }
}
