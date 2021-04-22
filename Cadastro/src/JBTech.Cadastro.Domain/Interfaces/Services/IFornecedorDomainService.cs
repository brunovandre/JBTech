using JBTech.Cadastro.Domain.Dto.Fornecedor;
using JBTech.Cadastro.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Services
{
    public interface IFornecedorDomainService
    {
        Task<Guid?> CriarAsync(CriarFornecedorDto dto);
        Task AtualizarAsync(AtualizarFornecedorDto dto);
        Task DeletarAsync(Guid id);
    }
}