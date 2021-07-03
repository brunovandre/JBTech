using JBTech.Core.Domain;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Cadastro.Infra.Context.Mappers
{
    public static class EntityMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Entity>(map =>
            {
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Deletado).SetIsRequired(true);
                map.MapMember(x => x.DataDelecao);
                map.MapMember(x => x.DataCriacao).SetIsRequired(true);
                map.MapMember(x => x.UltimaModificacao).SetIsRequired(true);

                map.SetIgnoreExtraElements(true);
            });
        }
    }
}
