using JBTech.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Vendas.Domain.Entities
{
    public class ItemVenda : Entity
    {
        public Guid IdProduto { get; private set; }
        public Guid IdVenda { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public int Quantidade { get; private set; }

        public virtual Produto Produto { get; private set; }
        public virtual Venda Venda { get; private set; }

        protected ItemVenda(){}

        public ItemVenda(Guid idProduto, Guid idVenda, decimal precoVenda, int quantidade)
        {
            IdProduto = idProduto;
            IdVenda = idVenda;
            PrecoVenda = precoVenda;
            Quantidade = quantidade;
        }

        public decimal ObterValorTotal()
            => PrecoVenda * Quantidade;
    }
}
