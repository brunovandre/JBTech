using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Infra.Context;
using JBTech.Core.Domain;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected IMongoCollection<T> Collection { get; }

        private readonly CadastroContext _context;

        public BaseRepository(
            CadastroContext context, string collectionName)
        {
             //MapClass();
            Collection = context.GetCollection<T>(collectionName);
            _context = context;
        }

        public async Task<T> GetByIdAsync(Guid id)
            => await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task InsertAsync(T entity)
        {
            SetAudit(entity, DatabaseOperationEnum.Insert);

            await Collection.InsertOneAsync(entity);
        }

        public async Task InsertRangeAsync(List<T> entities)
        {
            var inserts = new List<WriteModel<T>>();
            foreach (var entity in entities)
            {
                SetAudit(entity, DatabaseOperationEnum.Insert);
                inserts.Add(new InsertOneModel<T>(entity));
            }

            await Collection.BulkWriteAsync(inserts, new BulkWriteOptions() { IsOrdered = false });
        }

        public async Task UpdateAsync(T entity)
        {
            SetAudit(entity, DatabaseOperationEnum.Update);
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);

            await Collection.ReplaceOneAsync(filter, entity);
        }

        public async Task UpdateRangeAsync(List<T> entities)
        {
            var updates = new List<WriteModel<T>>();
            foreach (var entity in entities)
            {
                var filter = Builders<T>.Filter.Where(e => e.Id.Equals(entity.Id));
                SetAudit(entity, DatabaseOperationEnum.Update);
                updates.Add(new ReplaceOneModel<T>(filter, entity));
            }

            await Collection.BulkWriteAsync(updates, new BulkWriteOptions() { IsOrdered = false });
        }

        public async Task DeleteAsync(T entity)
        {
            SetAudit(entity, DatabaseOperationEnum.Delete);
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            await Collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteRangeAsync(List<T> entities)
        {
            var deletes = new List<WriteModel<T>>();
            foreach (var entity in entities)
            {
                var filter = Builders<T>.Filter.Where(e => e.Id.Equals(entity.Id));
                SetAudit(entity, DatabaseOperationEnum.Delete);
                deletes.Add(new ReplaceOneModel<T>(filter, entity));
            }

            await Collection.BulkWriteAsync(deletes, new BulkWriteOptions() { IsOrdered = false });
        }

        public async Task<List<T>> GetAllAsync()
            => await Collection.Find(x => !x.Deletado).ToListAsync();

        public async Task<IClientSessionHandle> BeginTransactionAsync()
            => await _context.BeginTransactionAsync();

        public async Task DeleteManyWithAuditAsync(Expression<Func<T, bool>> expression)
        {
            var entities = await Collection.Find(expression).ToListAsync();

            foreach (var entity in entities)
            {
                SetAudit(entity, DatabaseOperationEnum.Delete);
                var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
                await Collection.ReplaceOneAsync(filter, entity);
            }
        }

        private void SetAudit(T entity, DatabaseOperationEnum operation)
        {
            if (!typeof(T).IsSubclassOf(typeof(Entity))) return;

            var utcNowAuditDate = DateTime.UtcNow;

            switch (operation)
            {
                case DatabaseOperationEnum.Insert:
                    entity.GetType().GetProperty("DataCriacao").SetValue(entity, utcNowAuditDate, null);
                    entity.GetType().GetProperty("UltimaModificacao").SetValue(entity, utcNowAuditDate, null);
                    break;
                case DatabaseOperationEnum.Update:
                    entity.GetType().GetProperty("DataDelecao").SetValue(entity, utcNowAuditDate, null);
                    break;
                case DatabaseOperationEnum.Delete:
                    entity.GetType().GetProperty("DataDelecao").SetValue(entity, utcNowAuditDate, null);
                    entity.GetType().GetProperty("Deletado").SetValue(entity, true, null);
                    break;
                default:
                    break;
            }
        }
    }

    public enum DatabaseOperationEnum
    {
        Insert = 1,
        Update = 2,
        Delete = 3
    }
}
