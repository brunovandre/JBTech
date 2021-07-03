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
        public int TotalEstoque { get; private set; }
        public decimal PrecoCusto { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public bool Ativo { get; private set; }

        public Produto(
            string nome,
            Guid categoriaId, 
            string nomeCategoria, 
            string nomeFornecedor, 
            Guid fornecedorId,
            decimal precoCusto,
            decimal precoVenda,
            int totalEstoque,
            bool ativo,
            Guid? id = null)
        {
            Nome = nome;
            CategoriaId = categoriaId;
            NomeCategoria = nomeCategoria;
            NomeFornecedor = nomeFornecedor;
            FornecedorId = fornecedorId;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
            Ativo = ativo;
            TotalEstoque = totalEstoque;

            GerarId(id);
        }

        public void Atualizar(
            string nome,
            Guid categoriaId,
            string nomeCategoria,
            string nomeFornecedor,
            Guid fornecedorId,
            decimal precoCusto,
            decimal precoVenda,
            int totalEstoque,
            bool ativo)
        {
            Nome = nome;
            CategoriaId = categoriaId;
            NomeCategoria = nomeCategoria;
            NomeFornecedor = nomeFornecedor;
            FornecedorId = fornecedorId;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
            Ativo = ativo;
            TotalEstoque = totalEstoque;
        }
    }
}
