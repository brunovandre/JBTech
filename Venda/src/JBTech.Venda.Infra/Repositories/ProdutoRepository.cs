using JBTech.Vendas.Domain.Entities;
using JBTech.Vendas.Domain.Interfaces.Repositories;
using JBTech.Vendas.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBTech.Vendas.Infra.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(VendaContext context) : base(context)
        {
        }

        public async Task<List<Produto>> ObterTodosPorIdsAsync(List<Guid> ids)
           => await Context.Produtos.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}
