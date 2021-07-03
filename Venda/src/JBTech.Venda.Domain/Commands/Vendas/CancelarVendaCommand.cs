using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Vendas.Domain.Commands
{
    public class CancelarVendaCommand : IRequest<Unit>
    {
        public Guid IdVenda { get; set; }

        public CancelarVendaCommand(Guid idVenda)
        {
            IdVenda = idVenda;
        }
    }
}
