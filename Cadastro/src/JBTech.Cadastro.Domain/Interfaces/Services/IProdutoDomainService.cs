using JBTech.Cadastro.Domain.Dto.Produto;
using JBTech.Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Services
{
    public interface IProdutoDomainService
    {
        Task<Guid?> CriarAsync(CriarProdutoDto dto);
        Task AtualizarAsync(AtualizarProdutoDto dto);
        Task DeletarAsync(Guid id);
    }
}
