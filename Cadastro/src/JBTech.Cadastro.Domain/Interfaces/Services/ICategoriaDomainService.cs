using JBTech.Cadastro.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Services
{
    public interface ICategoriaDomainService
    {
        Task CriarAsync(Categoria fornecedor);
        Task AtualizarAsync(Categoria fornecedor);
        Task DeletarAsync(Guid id);
    }
}
