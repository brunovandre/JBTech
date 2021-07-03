using JBTech.Cadastro.Domain.Entities;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Infra.Context;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Infra.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(CadastroContext context) : base(context, CollectionsName.Categoria)
        {
            
        }

        public async Task<bool> NomeEstaDisponivelAsync(string nome, Guid? id = null)
        {
            var duplicatas =  await Collection.CountDocumentsAsync(x => x.Nome.ToLower() == nome.ToLower() && x.Id != id);

            return duplicatas <= 0;
        }

        public async Task<string> ObterNomePorIdAsync(Guid id)
            => await Collection.Find(x => x.Id == id).Project(x => x.Nome).FirstOrDefaultAsync();
    }
}
