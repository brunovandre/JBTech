using JBTech.Core.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(Guid id);
        Task InsertAsync(T entity);
        Task InsertRangeAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(List<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(List<T> entities);
        Task<List<T>> GetAllAsync();
        Task<IClientSessionHandle> BeginTransactionAsync();
        Task DeleteManyWithAuditAsync(Expression<Func<T, bool>> expression);
    }
}
