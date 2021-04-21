using JBTech.Core.Domain;
using System;

namespace JBTech.Cadastro.Domain.Entities
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Guid CategoriaId { get; private set; }
        public string NomeCategoria { get; private set; }
        public string NomeFornecedor { get; private set; }
        public Guid FornecedorId { get; private set; }
        public int TotalEsqtoque { get; private set; }
        public decimal PrecoCusto { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public bool Ativo { get; private set; }

        public Produto(string nome, Guid categoriaId, string nomeCategoria, string nomeFornecedor, Guid fornecedorId, bool ativo)
        {
            Nome = nome;
            CategoriaId = categoriaId;
            NomeCategoria = nomeCategoria;
            NomeFornecedor = nomeFornecedor;
            FornecedorId = fornecedorId;
            Ativo = ativo;

            GerarId();
        }

        public void Atualizar(string nome, Guid categoriaId, string nomeCategoria, string nomeFornecedor, Guid fornecedorId, bool ativo)
        {
            Nome = nome;
            CategoriaId = categoriaId;
            NomeCategoria = nomeCategoria;
            NomeFornecedor = nomeFornecedor;
            FornecedorId = fornecedorId;
            Ativo = ativo;
        }

        public void SetTotalEstoque(int total)
            => TotalEsqtoque = total;

        public void SetPrecos(decimal precoVenda, decimal precoCusto)
        {
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
        }
    }
}
