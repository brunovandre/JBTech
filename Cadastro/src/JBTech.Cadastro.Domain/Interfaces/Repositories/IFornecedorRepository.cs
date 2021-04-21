using JBTech.Cadastro.Domain.Entities;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Repositories
{
    public interface IFornecedorRepository : IBaseRepository<Fornecedor>
    {
        Task<bool> CnpjEstaDisponivelAsync(string cnpj);
    }
}
