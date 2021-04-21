using JBTech.Cadastro.Domain.Entities;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Infra.Context;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Infra.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(CadastroContext context) : base(context, CollectionsName.Categoria)
        {
        }

        public async Task<bool> NomeEstaDisponivelAsync(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
                nome = nome.ToUpper();

            var duplicatas =  await Collection.CountDocumentsAsync(x => x.Nome.ToLower().Equals(nome.ToLower()));

            return duplicatas <= 0;
        }
    }
}
