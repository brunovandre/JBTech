using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Infra.Context;
using JBTech.Cadastro.Infra.Repositories;
using JBTech.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Cadastro.Infra
{
    public static class ServiceCollections
    {
        public static IServiceCollection RegistrarDependenciasInfra(this IServiceCollection services)
        {
            services.RegistrarDependenciasDominioCore();

            services.AddScoped<CadastroContext>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            CadastroMappings.MapearCollections();

            return services;
        }
    }
}
