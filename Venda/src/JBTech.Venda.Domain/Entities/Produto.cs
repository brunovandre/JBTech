using JBTech.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Vendas.Domain.Entities
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Guid CategoriaId { get; private set; }
        public string NomeCategoria { get; private set; }
        public int TotalEstoque { get; private set; }
        public decimal PrecoVenda { get; private set; }

        public ICollection<ItemVenda> ItemsVenda { get; private set; }

        protected Produto() { }

        public Produto(
            string nome,
            Guid categoriaId, 
            string nomeCategoria, 
            int totalEstoque,
            decimal precoVenda)
        {
            Nome = nome;
            CategoriaId = categoriaId;
            NomeCategoria = nomeCategoria;
            TotalEstoque = totalEstoque;
            PrecoVenda = precoVenda;
        }
    }
}
