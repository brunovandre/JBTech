using JBTech.Cadastro.Domain.Interfaces.Services;
using JBTech.Cadastro.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Cadastro.Domain
{
    public static class ServiceCollections
    {
        public static IServiceCollection RegistrarDependenciasDominio(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaDomainService, CategoriaDomainService>();
            services.AddScoped<IFornecedorDomainService, FornecedorDomainService>();
            services.AddScoped<IProdutoDomainService, ProdutoDomainService>();
            services.AddScoped<IUsuarioDomainService, UsuarioDomainService>();

            return services;
        }
    }
}
