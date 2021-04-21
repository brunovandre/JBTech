using JBTech.Cadastro.Domain.Entities;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Domain.Interfaces.Services;
using JBTech.Core.Notifications;
using System;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Services
{
    public class ProdutoDomainService : BaseDomainService, IProdutoDomainService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoDomainService(
            IProdutoRepository produtoRepository,
            INotificationHandler notification) : base(notification)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task CriarAsync(Produto produto)
        {
            if (!await _produtoRepository.NomeEstaDisponivelAsync(produto.Nome)) return;

            await _produtoRepository.InsertAsync(produto);
        }

        public async Task AtualizarAsync(Produto novoProduto)
        {
            var produtoDb = await _produtoRepository.GetByIdAsync(novoProduto.Id);
            if (produtoDb == null) return;
            
            if (!await _produtoRepository.NomeEstaDisponivelAsync(novoProduto.Nome)) return;

            produtoDb.Atualizar(novoProduto.Nome, novoProduto.CategoriaId, novoProduto.NomeCategoria, novoProduto.NomeFornecedor, novoProduto.FornecedorId, novoProduto.Ativo);

            await _produtoRepository.UpdateAsync(produtoDb);
        }

        public async Task DeletarAsync(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null) return;

            await _produtoRepository.UpdateAsync(produto);
        }
    }
}
