using JBTech.Core;
using JBTech.Vendas.Domain.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JBTech.Vendas.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegistrarDependenciasDominio(this IServiceCollection services)
        {
            services.RegistrarDependenciasDominioCore();

            services.AddMediatR(typeof(EfetuarVendaCommand).GetTypeInfo().Assembly);

            return services;
        }
    }
}
