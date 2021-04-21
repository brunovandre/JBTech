using JBTech.Cadastro.Domain.Entities;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Domain.Interfaces.Services;
using JBTech.Core.Notifications;
using System;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Services
{
    public class FornecedorDomainService : BaseDomainService, IFornecedorDomainService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProdutoRepository _produtoRepository;

        public FornecedorDomainService(
            IFornecedorRepository fornecedorRepository,
            IProdutoRepository produtoRepository,
            INotificationHandler notification) : base(notification)
        {
            _fornecedorRepository = fornecedorRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task CriarAsync(Fornecedor fornecedor)
        {
            if (!await _fornecedorRepository.CnpjEstaDisponivelAsync(fornecedor.CNPJ)) return;

            await _fornecedorRepository.InsertAsync(fornecedor);
        }

        public async Task AtualizarAsync(Fornecedor novoFornecedor)
        {
            var fornecedorDb = await _fornecedorRepository.GetByIdAsync(novoFornecedor.Id);
            if (fornecedorDb == null) return;
            
            if (!await _fornecedorRepository.CnpjEstaDisponivelAsync(novoFornecedor.CNPJ)) return;

            fornecedorDb.Atualizar(novoFornecedor.Nome, novoFornecedor.CNPJ, novoFornecedor.Email, novoFornecedor.Telefone, novoFornecedor.Endereco);

            await _fornecedorRepository.UpdateAsync(fornecedorDb);
        }

        public async Task DeletarAsync(Guid id)
        {
            var fornecedor = await _fornecedorRepository.GetByIdAsync(id);

            if (fornecedor == null) return;

            if (await _produtoRepository.ExisteProdutosComEsseFornecedorAsync(fornecedor.Id)) return;

            await _fornecedorRepository.DeleteAsync(fornecedor);
        }
    }
}
