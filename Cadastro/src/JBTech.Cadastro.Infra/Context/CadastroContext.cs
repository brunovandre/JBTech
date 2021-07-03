using JBTech.Cadastro.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Infra.Context
{
    public class CadastroContext
    {
        public IMongoDatabase _database { get; private set; }
        private MongoClient _client { get; set; }

        public CadastroContext(IConfiguration configuration)
        {
            _client = new MongoClient(configuration.GetConnectionString("MongoDbUri"));
            _database = _client.GetDatabase(configuration.GetConnectionString("MongoDbDatabase"));
        }

        public IMongoCollection<T> GetCollection<T>(string name)
            => _database.GetCollection<T>(name);

        public async Task<IClientSessionHandle> BeginTransactionAsync()
            => await _client.StartSessionAsync();

        //private async Task aa()
        //{            
        //    var options = new CreateIndexOptions() { Unique = true };
        //    var nomeIndex = 
        //    var deletadoIndex = new IndexKeysDefinitionBuilder<Categoria>().Text(x => x.Deletado);
        //    var dataDelecaoIndex = new IndexKeysDefinitionBuilder<Categoria>().Ascending(x => x.DataDelecao);

        //    var index = new IndexKeysDefinitionBuilder<Categoria>().Combine(nomeIndex, deletadoIndex, dataDelecaoIndex);

        //    var indexModel = new CreateIndexModel<Categoria>(index, options);

        //    await _database.GetCollection<Categoria>(CollectionsName.Categoria).Indexes.CreateOneAsync(indexModel);
        //}
    }
}
