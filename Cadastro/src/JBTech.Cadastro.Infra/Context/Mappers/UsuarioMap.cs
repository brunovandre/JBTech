using JBTech.Cadastro.Domain.Entities;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Cadastro.Infra.Context.Mappers
{
    public class UsuarioMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Usuario>(map =>
            {
                map.MapCreator(c => new Usuario(c.Nome, c.Sobrenome, c.Email, c.Senha, c.Cpf, c.Id));
                
                map.MapMember(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.Sobrenome).SetIsRequired(true);
                map.MapMember(x => x.Email).SetIsRequired(true);
                map.MapMember(x => x.Senha).SetIsRequired(true);
                map.MapMember(x => x.Cpf).SetIsRequired(true);

            });
        }
    }
}
