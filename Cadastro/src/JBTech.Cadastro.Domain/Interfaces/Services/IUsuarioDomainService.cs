using JBTech.Cadastro.Domain.Dto.Usuario;
using System;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        Task<Guid?> CriarAsync(CriarUsuarioDto dto);
        Task AtualizarAsync(AtualizarUsuarioDto dto);
        Task InativarAsync(Guid id);
    }
}
