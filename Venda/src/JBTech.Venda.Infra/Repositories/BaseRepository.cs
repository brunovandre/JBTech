using JBTech.Core.Domain;
using JBTech.Vendas.Domain.Interfaces.Repositories;
using JBTech.Vendas.Infra.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBTech.Vendas.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity 
    {
        protected readonly VendaContext Context;

        public BaseRepository(VendaContext context)
        {
            Context = context;
        }

        public async Task<T> InsertAndSaveChangesAsync(T entity)
        {
            await Context.AddAsync(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task InsertRangeAndSaveChangesAsync(List<T> entities)
        {
            await Context.AddRangeAsync(entities);

            await Context.SaveChangesAsync();
        }

        public async Task UpdateAndSaveChangesAsync(T entity)
        {
            Context.Update(entity);

            await Context.SaveChangesAsync();
        }

        public async Task UpdateRangeAndSaveChangesAsync(List<T> entities)
        {
            Context.UpdateRange(entities);

            await Context.SaveChangesAsync();
        }

        public async Task DeleteAndSaveChangesAsync(T entity)
        {
            Context.Remove(entity);

            await Context.SaveChangesAsync();
        }

        public async Task DeleteRangeAndSaveChangesAsync(List<T> entities)
        {
            Context.RemoveRange(entities);

            await Context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginAsync()
            => await Context.Database.BeginTransactionAsync();

    }
}
