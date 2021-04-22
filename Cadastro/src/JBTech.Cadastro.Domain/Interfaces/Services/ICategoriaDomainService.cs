using JBTech.Cadastro.Domain.Dto.Categoria;
using JBTech.Cadastro.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Services
{
    public interface ICategoriaDomainService
    {
        Task<Guid?> CriarAsync(CriarCategoriaDto dto);
        Task AtualizarAsync(AtualizarCategoriaDto dto);
        Task DeletarAsync(Guid id);
    }
}
