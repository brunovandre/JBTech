using JBTech.Vendas.Domain.Entities;
using JBTech.Vendas.Domain.Interfaces.Repositories;
using JBTech.Vendas.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JBTech.Vendas.Infra.Repositories
{
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        public VendaRepository(VendaContext context) : base(context)
        {
        }

        public async Task SalvarItensVendaAsync(List<ItemVenda> itens)
        {
            await Context.ItemsVenda.AddRangeAsync(itens);

            await Context.SaveChangesAsync();
        }

        public async Task<Venda> ObterPorIdAsync(Guid id)
            => await Context.Vendas.FirstOrDefaultAsync(x => x.Id == id);
    }
}
