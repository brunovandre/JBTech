using JBTech.Vendas.Domain.Interfaces.Repositories;
using JBTech.Vendas.Infra.Context;
using JBTech.Vendas.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Vendas.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegistrarDepedenciasInfra(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<VendaContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
