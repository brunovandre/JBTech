using JBTech.Cadastro.Infra.Context.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Cadastro.Infra.Context
{
    public static class CadastroMappings
    {
        public static void MapearCollections()
        {
            EntityMap.Configure();
            CategoriaMap.Configure();
            FornecedorMap.Configure();
            ProdutoMap.Configure();
            UsuarioMap.Configure();
        }
    }
}
