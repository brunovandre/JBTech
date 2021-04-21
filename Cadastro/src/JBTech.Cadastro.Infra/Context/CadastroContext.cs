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
            _client = new MongoClient(configuration["ConnectionStrings:MongoDB:Uri"]);
            _database = _client.GetDatabase(configuration["ConnectionStrings:MongoDB:DatabaseName"]);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
            => _database.GetCollection<T>(name);

        public async Task<IClientSessionHandle> BeginTransactionAsync()
            => await _client.StartSessionAsync();
    }
}
