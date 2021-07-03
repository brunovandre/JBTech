using JBTech.Core.Domain;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBTech.Vendas.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> InsertAndSaveChangesAsync(T entity);
        Task InsertRangeAndSaveChangesAsync(List<T> entities);
        Task UpdateAndSaveChangesAsync(T entity);
        Task UpdateRangeAndSaveChangesAsync(List<T> entities);
        Task DeleteAndSaveChangesAsync(T entity);
        Task DeleteRangeAndSaveChangesAsync(List<T> entities);
        Task<IDbContextTransaction> BeginAsync();
    }
}
