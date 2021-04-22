using AutoMapper;
using JBTech.Cadastro.Domain.Dto.Categoria;
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
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;

        public CategoriaDomainService(
            IMapper mapper,
            ICategoriaRepository categoriaRepository,
            IProdutoRepository produtoRepository,
            INotificationHandler notification) : base(notification)
        {
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<Guid?> CriarAsync(CriarCategoriaDto dto)
        {
            var categoria = _mapper.Map<Categoria>(dto);

            await ValidarSeNomeEstaDisponivel(dto.Nome);

            if (Notification.HasErrorNotifications()) return null;

            await _categoriaRepository.InsertAsync(categoria);

            return categoria.Id;
        }

        public async Task AtualizarAsync(AtualizarCategoriaDto dto)
        {
            var categoriaDb = await _categoriaRepository.GetByIdAsync(dto.Id);

            ValidarSeCategoriaExiste(categoriaDb);

            await ValidarSeNomeEstaDisponivel(dto.Nome, dto.Id);

            categoriaDb.Atualizar(dto.Nome);

            if (Notification.HasErrorNotifications()) return;

            await _categoriaRepository.UpdateAsync(categoriaDb);
        }

        public async Task DeletarAsync(Guid id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            ValidarSeCategoriaExiste(categoria);

            await ValidarSeExistemProdutosVinculados(id);

            if (Notification.HasErrorNotifications()) return;

            await _categoriaRepository.DeleteAsync(categoria);
        }

        private async Task ValidarSeNomeEstaDisponivel(string nomeCategoria, Guid? id = null)
        {
            if (!await _categoriaRepository.NomeEstaDisponivelAsync(nomeCategoria, id))
                Notification.RaiseError("CategoriaNomeIndisponivel", "Já existe uma categoria com o mesmo nome");
        }

        private async Task ValidarSeExistemProdutosVinculados(Guid id)
        {
            if (await _produtoRepository.ExisteProdutosComEssaCategoriaAsync(id))
                Notification.RaiseError("ProdutosVinculadosCategoria", "Não foi possível excluir a categoria pois existem produtos vinculados a mesma.");
        }

        private void ValidarSeCategoriaExiste(Categoria categoria)
        {
            if (categoria == null)
                NotificarEntidadeNaoEncontrada("Categoria");
        }
    }
}
