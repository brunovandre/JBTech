using JBTech.Vendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBTech.Vendas.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<List<Produto>> ObterTodosPorIdsAsync(List<Guid> ids);
    }
}
