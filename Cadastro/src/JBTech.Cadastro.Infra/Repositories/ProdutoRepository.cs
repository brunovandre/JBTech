using JBTech.Cadastro.Domain.Entities;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Infra.Context;
using System;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Infra.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CadastroContext context) : base(context, CollectionsName.Produto)
        {
        }

        public async Task<bool> NomeEstaDisponivelAsync(string nome, Guid? id = null)
        {
            if (!string.IsNullOrWhiteSpace(nome))
                nome = nome.ToUpper();

            var duplicatas = await Collection.CountDocumentsAsync(x => x.Nome.ToLower() == nome.ToLower() && x.Id != id);

            return duplicatas <= 0;
        }

        public async Task<bool> ExisteProdutosComEssaCategoriaAsync(Guid id)
           => (await Collection.CountDocumentsAsync(x => x.CategoriaId == id && !x.Deletado)) > 0;

        public async Task<bool> ExisteProdutosComEsseFornecedorAsync(Guid id)
          => (await Collection.CountDocumentsAsync(x => x.FornecedorId == id && !x.Deletado)) > 0;
    }
}
