using JBTech.Vendas.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Vendas.Domain.Commands
{
    public class EfetuarVendaCommand : IRequest<Unit>
    {
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public List<ItemVendaRequest> Itens { get; set; }
        public Guid IdUsuario { get; set; }

        public EfetuarVendaCommand()
        {
            Itens = new List<ItemVendaRequest>();
        }
    }

    public class ItemVendaRequest
    {
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
