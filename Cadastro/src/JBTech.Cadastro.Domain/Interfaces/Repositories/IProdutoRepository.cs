using JBTech.Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<bool> NomeEstaDisponivelAsync(string nome);
        Task<bool> ExisteProdutosComEssaCategoriaAsync(Guid id);
        Task<bool> ExisteProdutosComEsseFornecedorAsync(Guid id);
    }
}
