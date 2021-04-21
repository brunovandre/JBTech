using JBTech.Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<bool> CpfeEmailEstaoDisponiveisAsync(string email, string cpf);
    }
}
