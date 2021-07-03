using JBTech.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Vendas.Domain.Entities
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public ICollection<Venda> Vendas { get; private set; }

        protected Usuario() { }

        public Usuario(string nome, string sobrenome, string email, string cpf)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Cpf = cpf;
        }
    }
}
