using JBTech.Vendas.Domain.Entities;
using JBTech.Vendas.Domain.Interfaces.Repositories;
using JBTech.Vendas.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Vendas.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(VendaContext context) : base(context)
        {
        }
    }
}
