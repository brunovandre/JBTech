using AutoMapper;
using JBTech.Cadastro.Domain.Dto.Fornecedor;
using JBTech.Cadastro.Domain.Entities;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Domain.Interfaces.Services;
using JBTech.Cadastro.Domain.ValueObjects;
using JBTech.Core.Notifications;
using System;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Services
{
    public class FornecedorDomainService : BaseDomainService, IFornecedorDomainService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public FornecedorDomainService(
            IMapper mapper,
            IFornecedorRepository fornecedorRepository,
            IProdutoRepository produtoRepository,
            INotificationHandler notification) : base(notification)
        {
            _fornecedorRepository = fornecedorRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<Guid?> CriarAsync(CriarFornecedorDto dto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(dto);

            await ValidarSeCnpjEstaDisponivel(dto.CNPJ);

            if (Notification.HasErrorNotifications()) return null;

            await _fornecedorRepository.InsertAsync(fornecedor);

            return fornecedor.Id;
        }

        public async Task AtualizarAsync(AtualizarFornecedorDto dto)
        {
            var fornecedorDb = await _fornecedorRepository.GetByIdAsync(dto.Id);
            
            ValidarSeFornecedorExiste(fornecedorDb);

            fornecedorDb.Atualizar(dto.Nome, dto.Email, dto.Telefone, _mapper.Map<Endereco>(dto.Endereco));

            if (Notification.HasErrorNotifications()) return;

            await _fornecedorRepository.UpdateAsync(fornecedorDb);
        }

        public async Task DeletarAsync(Guid id)
        {
            var fornecedor = await _fornecedorRepository.GetByIdAsync(id);
            
            ValidarSeFornecedorExiste(fornecedor);

            await ValidarSeExistemProdutosVinculados(id);

            if (Notification.HasErrorNotifications()) return;

            await _fornecedorRepository.DeleteAsync(fornecedor);
        }

        private async Task ValidarSeCnpjEstaDisponivel(string cnpj)
        {
            if (!await _fornecedorRepository.CnpjEstaDisponivelAsync(cnpj))
                Notification.RaiseError("CnpjIndisponivel", "Cnpj indisponível");
        }

        private async Task ValidarSeExistemProdutosVinculados(Guid id)
        {
            if (await _produtoRepository.ExisteProdutosComEsseFornecedorAsync(id))
                Notification.RaiseError("ProdutosVinculadosFornecedor", "Não foi possível excluir o fornecedor pois existem produtos vinculados ao mesmo.");
        }

        private void ValidarSeFornecedorExiste(Fornecedor fornecedor)
        {
            if (fornecedor == null)
                NotificarEntidadeNaoEncontrada("Fornecedor");
        }
    }
}
