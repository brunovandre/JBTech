using JBTech.Cadastro.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace JBTech.Cadastro.Infra.Context.Mappers
{
    public static class CategoriaMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Categoria>(map =>
            {
                map.MapCreator(c => new Categoria(c.Nome, c.Id));
                map.MapMember(x => x.Nome).SetIsRequired(true);
            });
        }
    }
}
