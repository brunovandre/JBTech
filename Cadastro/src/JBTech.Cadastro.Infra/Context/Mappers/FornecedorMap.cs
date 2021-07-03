using JBTech.Cadastro.Domain.Entities;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Cadastro.Infra.Context.Mappers
{
    public static class FornecedorMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Fornecedor>(map =>
            {
                map.MapCreator(c => new Fornecedor(c.Nome, c.CNPJ, c.Email, c.Telefone, c.Endereco, c.Id));

                map.MapMember(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.CNPJ).SetIsRequired(true);
                map.MapMember(x => x.Telefone).SetIsRequired(true);
                map.MapMember(x => x.Email);
                map.MapMember(x => x.Endereco);
            });
        }
    }
}
