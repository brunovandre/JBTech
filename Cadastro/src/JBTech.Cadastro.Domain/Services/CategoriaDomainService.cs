using JBTech.Cadastro.Domain.Entities;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Domain.Interfaces.Services;
using JBTech.Core.Notifications;
using System;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Services
{
    public class CategoriaDomainService : BaseDomainService, ICategoriaDomainService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;

        public CategoriaDomainService(
            ICategoriaRepository categoriaRepository,
            IProdutoRepository produtoRepository,
            INotificationHandler notification) : base(notification)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task CriarAsync(Categoria categoria)
        {
            if (!await _categoriaRepository.NomeEstaDisponivelAsync(categoria.Nome)) return;

            await _categoriaRepository.InsertAsync(categoria);
        }

        public async Task AtualizarAsync(Categoria novaCategoria)
        {
            var categoriaDb = await _categoriaRepository.GetByIdAsync(novaCategoria.Id);
            if (categoriaDb == null) return;

            if (!await _categoriaRepository.NomeEstaDisponivelAsync(novaCategoria.Nome)) return;

            categoriaDb.Atualizar(novaCategoria.Nome);

            await _categoriaRepository.UpdateAsync(categoriaDb);
        }

        public async Task DeletarAsync(Guid id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            if (categoria == null) return;
            
            if (await _produtoRepository.ExisteProdutosComEssaCategoriaAsync(categoria.Id)) return;

            await _categoriaRepository.DeleteAsync(categoria);
        }
    }
}
