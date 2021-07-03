using JBTech.Core.Notifications;
using JBTech.Vendas.Domain.Commands;
using JBTech.Vendas.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JBTech.Vendas.Domain.Handlers.Vendas
{
    public class CancelarVendaHandler : IRequestHandler<CancelarVendaCommand, Unit>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly INotificationHandler _notification;

        public CancelarVendaHandler(
            INotificationHandler notification,
            IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
            _notification = notification;
        }
        
        public async Task<Unit> Handle(CancelarVendaCommand request, CancellationToken cancellationToken)
        {
            var venda = await _vendaRepository.ObterPorIdAsync(request.IdVenda);
            if(venda == null)
            {
                _notification.RaiseError("VendaNaoEncontrada", "Venda não encontrada");
                return Unit.Value;
            }

            if(venda.Status != Enums.StatusVendaEnum.EmAndamento)
            {
                _notification.RaiseError("StatusVendaInvalida", "Apenas vendas com status em andamento pode ser cancelada");
                return Unit.Value;
            }

            venda.CancelarVenda();

            if (!_notification.HasErrorNotifications())
                await _vendaRepository.UpdateAndSaveChangesAsync(venda);

            return Unit.Value;
        }
    }
}
