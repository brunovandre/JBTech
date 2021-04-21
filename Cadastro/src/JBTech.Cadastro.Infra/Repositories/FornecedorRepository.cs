using JBTech.Cadastro.Domain.Entities;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Infra.Context;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace JBTech.Cadastro.Infra.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(CadastroContext context) : base(context, CollectionsName.Fornecedor)
        {
        }

        public async Task<bool> CnpjEstaDisponivelAsync(string cnpj)
            => (await Collection.CountDocumentsAsync(x => x.CNPJ.Equals(cnpj))) <= 0;
    }
}
