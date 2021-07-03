using JBTech.Cadastro.Domain.Entities;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Infra.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CadastroContext context) : base(context, CollectionsName.Usuario)
        {
        }

        public async Task<bool> CpfeEmailEstaoDisponiveisAsync(string email, string cpf)
           => (await Collection.CountDocumentsAsync(x => x.Email.ToLower() == email.ToLower() || x.Cpf == cpf)) <= 0;
    }
}
