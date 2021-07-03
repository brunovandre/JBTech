using AutoMapper;
using JBTech.Cadastro.Domain.Dto.Produto;
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
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public ProdutoDomainService(
            IMapper mapper,
            IProdutoRepository produtoRepository,
            ICategoriaRepository categoriaRepository,
            IFornecedorRepository fornecedorRepository,
            INotificationHandler notification) : base(notification)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<Guid?> CriarAsync(CriarProdutoDto dto)
        {
            dto.NomeCategoria = await _categoriaRepository.ObterNomePorIdAsync(dto.CategoriaId);
            dto.NomeFornecedor = await _fornecedorRepository.ObterNomePorIdAsync(dto.FornecedorId);

            await ValidarSeNomeEstaDisponivel(dto.Nome);

            var produto = _mapper.Map<Produto>(dto);

            if (Notification.HasErrorNotifications()) return null;

            await _produtoRepository.InsertAsync(produto);

            return produto.Id;
        }

        public async Task AtualizarAsync(AtualizarProdutoDto dto)
        {
            var produtoDb = await _produtoRepository.GetByIdAsync(dto.Id);

            ValidarSeProdutoExiste(produtoDb);

            await ValidarSeNomeEstaDisponivel(dto.Nome, dto.Id);

            var nomeCategoria = await _categoriaRepository.ObterNomePorIdAsync(dto.CategoriaId);
            var nomeFornecedor = await _fornecedorRepository.ObterNomePorIdAsync(dto.FornecedorId);

            produtoDb.Atualizar(dto.Nome, dto.CategoriaId, nomeCategoria, nomeFornecedor, dto.FornecedorId, dto.PrecoCusto, dto.PrecoVenda, dto.TotalEstoque, dto.Ativo);

            if (Notification.HasErrorNotifications()) return;

            await _produtoRepository.UpdateAsync(produtoDb);
        }

        public async Task DeletarAsync(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            
            ValidarSeProdutoExiste(produto);

            if (Notification.HasErrorNotifications()) return;

            await _produtoRepository.DeleteAsync(produto);
        }

        private void ValidarSeProdutoExiste(Produto produto)
        {
            if (produto == null)
                NotificarEntidadeNaoEncontrada("Produto");
        }

        private async Task ValidarSeNomeEstaDisponivel(string nomeProduto, Guid? id = null)
        {
            if (!await _produtoRepository.NomeEstaDisponivelAsync(nomeProduto, id))
                Notification.RaiseError("ProdutoNomeIndisponivel", "Já existe um produto com o mesmo nome");
        }
    }
}
