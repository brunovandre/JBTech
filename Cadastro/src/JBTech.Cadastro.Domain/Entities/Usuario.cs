using JBTech.Cadastro.Domain.ValueObjects;
using JBTech.Core.Domain;
using System;
using System.Collections.Generic;

namespace JBTech.Cadastro.Domain.Entities
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Cpf { get; private set; }
        public bool Ativo { get; private set; }

        private List<Endereco> _enderecos;
        public IReadOnlyCollection<Endereco> Enderecos => _enderecos?.AsReadOnly();

        public Usuario(string nome, string sobrenome, string email, string senha, string cpf, Guid? id = null)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Senha = senha;
            Cpf = cpf;

            _enderecos = new List<Endereco>();
            GerarId(id);
        }


        public void Atualizar(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public void AdicionarEndereco(Endereco endereco)
            => _enderecos.Add(endereco);

        public void RemoverEndereco(string cep)
           => _enderecos.RemoveAll(x => x.Cep.ToLower().Equals(cep.ToLower()));

        public void Inativar()
            => Ativo = false;
    }
}
