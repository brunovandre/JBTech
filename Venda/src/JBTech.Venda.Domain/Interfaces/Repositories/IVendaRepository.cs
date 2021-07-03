using JBTech.Vendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBTech.Vendas.Domain.Interfaces.Repositories
{
    public interface IVendaRepository : IBaseRepository<Venda>
    {
        Task SalvarItensVendaAsync(List<ItemVenda> itens);
        Task<Venda> ObterPorIdAsync(Guid id);
    }
}
