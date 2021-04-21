using JBTech.Core.Domain;

namespace JBTech.Cadastro.Domain.Entities
{
    public class Categoria : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        public Categoria(string nome)
        {
            Nome = nome;
            GerarId();
        }

        public void Atualizar(string nome)
        {
            Nome = nome;
        }
    }
}
