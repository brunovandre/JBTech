using JBTech.Core.Domain;
using System;

namespace JBTech.Cadastro.Domain.Entities
{
    public class Categoria : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        public Categoria(string nome, Guid? id = null)
        {
            Nome = nome;
            GerarId(id);
        }

        public void Atualizar(string nome)
        {
            Nome = nome;
        }
    }
}
