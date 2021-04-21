using JBTech.Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        Task CriarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task InativarAsync(Guid id);
    }
}
