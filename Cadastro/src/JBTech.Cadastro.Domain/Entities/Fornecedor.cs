using JBTech.Cadastro.Domain.ValueObjects;
using JBTech.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Cadastro.Domain.Entities
{
    public class Fornecedor : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public Endereco Endereco { get; private set; }

        public Fornecedor(string nome, string cnpj, string email, string telefone, Endereco endereco, Guid? id = null)
        {
            Nome = nome;
            CNPJ = cnpj;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;

            GerarId(id);
        }

        public void Atualizar(string nome, string email, string telefone, Endereco endereco)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
