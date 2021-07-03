using JBTech.Core.Domain;
using JBTech.Vendas.Domain.Enums;
using System;
using System.Collections.Generic;

namespace JBTech.Vendas.Domain.Entities
{
    public class Venda : Entity, IAggregateRoot
    {
        public DateTime DataCompra { get; private set; }
        public DateTime? DataCancelamento { get; private set; }
        public DateTime? DataFinalizacao { get; private set; }
        public Guid? NumeroCancelamento { get; private set; }
        public FormaPagamentoEnum FormaPagamento { get; private set; }
        public decimal ValorTotal { get; private set; }
        public Guid IdUsuario { get; private set; }
        public StatusVendaEnum Status { get; private set; }

        public virtual Usuario Usuario { get; private set; }
        public ICollection<ItemVenda> ItemsVenda { get; private set; }

        protected Venda() { }

        public Venda(
            FormaPagamentoEnum formaPagamento,
            Guid idUsuario)
        {
            DataCompra = DateTime.Now;
            Status = StatusVendaEnum.EmAndamento;
            FormaPagamento = formaPagamento;
            IdUsuario = idUsuario;
            GerarId();
        }

        public void CancelarVenda()
        {
            Status = StatusVendaEnum.Cancelada;
            DataCancelamento = DateTime.Now;
            NumeroCancelamento = Guid.NewGuid();
        }

        public void AdicionarItemVenda(ItemVenda item)
        {
            ItemsVenda.Add(item);
            ValorTotal += item.PrecoVenda * item.Quantidade;
        }
    }
}
