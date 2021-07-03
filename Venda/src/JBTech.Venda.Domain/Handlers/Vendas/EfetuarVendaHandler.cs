using JBTech.Core.Notifications;
using JBTech.Vendas.Domain.Commands;
using JBTech.Vendas.Domain.Entities;
using JBTech.Vendas.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JBTech.Vendas.Domain.Handlers.Vendas
{
    public class EfetuarVendaHandler : IRequestHandler<EfetuarVendaCommand, Unit>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly INotificationHandler _notification;

        public EfetuarVendaHandler(
            IProdutoRepository produtoRepository,
            INotificationHandler notification,
            IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
            _notification = notification;
        }
        
        public async Task<Unit> Handle(EfetuarVendaCommand request, CancellationToken cancellationToken)
        {
            var produtos = await _produtoRepository.ObterTodosPorIdsAsync(request.Itens.Select(x => x.IdProduto).ToList());

            ValidarProdutos(produtos, request);

            ValidarEstoque(produtos, request);

            if (_notification.HasErrorNotifications())
                return Unit.Value;

            var venda = CriarVenda(produtos, request);

            if (_notification.HasErrorNotifications())
                return Unit.Value;

            using (var uow = await _vendaRepository.BeginAsync())
            {
                await _vendaRepository.InsertAndSaveChangesAsync(venda);

                await _vendaRepository.SalvarItensVendaAsync(venda.ItemsVenda.ToList());

                await uow.CommitAsync();
            }

            return Unit.Value;
        }

        private Venda CriarVenda(List<Produto> produtos, EfetuarVendaCommand request)
        {
            var venda = new Venda(request.FormaPagamento, request.IdUsuario);

            foreach (var produto in produtos)
            {
                venda.AdicionarItemVenda(
                    new ItemVenda(
                        produto.Id,
                        venda.Id,
                        produto.PrecoVenda,
                        request.Itens.FirstOrDefault(x => produto.Id == x.IdProduto).Quantidade));
            }

            return venda;
        }

        private void ValidarProdutos(List<Produto> produtos, EfetuarVendaCommand request)
        {
            if (produtos.Count != request.Itens.Count)
                _notification.RaiseError("ProdutosNaoEncontrados", "Alguns produtos não foram encontrados");
        }

        private void ValidarEstoque(List<Produto> produtos, EfetuarVendaCommand request)
        {
            foreach (var produto in produtos)
            {
                var produtoRequest = request.Itens.FirstOrDefault(x => x.IdProduto == produto.Id);
                if (produto.TotalEstoque < produtoRequest.Quantidade)
                    _notification.RaiseError("EstoqueInsuficiente", $"Não há estoque suficiente para o produto {produto.Nome}.");
            }
        }
    }
}