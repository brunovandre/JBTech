using JBTech.Catalogo.Infra.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Catalogo.Infra
{
    public static class CatalogoInfraServiceCollections
    {
        public static IServiceCollection RegisterInfraDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddElasticsearch(configuration);
            return services;
        }

        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["elasticsearch:url"];
            var defaultIndex = configuration["elasticsearch:index"];

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex);

            var client = new ElasticClient(settings);

            services.AddSingleton(client);

            CreateIndex(client, defaultIndex);
        }


        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<Produto>(x => x.AutoMap())
            );
        }
    }
}
