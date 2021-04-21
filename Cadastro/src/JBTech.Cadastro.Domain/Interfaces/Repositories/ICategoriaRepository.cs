using JBTech.Cadastro.Domain.Entities;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        Task<bool> NomeEstaDisponivelAsync(string nome);
    }
}
