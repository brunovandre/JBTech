using JBTech.Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Services
{
    public interface IProdutoDomainService
    {
        Task CriarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task DeletarAsync(Guid id);
    }
}
