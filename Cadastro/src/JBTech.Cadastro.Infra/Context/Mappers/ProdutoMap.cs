using JBTech.Cadastro.Domain.Entities;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Cadastro.Infra.Context.Mappers
{
    public class ProdutoMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Produto>(map =>
            {
                map.MapCreator(c => new Produto(c.Nome, c.CategoriaId, c.NomeCategoria, c.NomeFornecedor, c.FornecedorId, c.PrecoCusto, c.PrecoVenda, c.TotalEstoque, c.Ativo, c.Id));

                map.MapMember(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.CategoriaId).SetIsRequired(true);
                map.MapMember(x => x.FornecedorId).SetIsRequired(true);
                map.MapMember(x => x.NomeCategoria);
                map.MapMember(x => x.NomeFornecedor);
                map.MapMember(x => x.PrecoCusto);
                map.MapMember(x => x.PrecoVenda);
                map.MapMember(x => x.Ativo);
            });
        }
    }
}
