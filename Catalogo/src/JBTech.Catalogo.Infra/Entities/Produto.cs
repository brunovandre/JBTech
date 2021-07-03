using System;

namespace JBTech.Catalogo.Infra.Entities
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Guid CategoriaId { get; private set; }
        public string NomeCategoria { get; private set; }
        public string NomeFornecedor { get; private set; }
        public Guid FornecedorId { get; private set; }
        public int TotalEstoque { get; private set; }
        public decimal PrecoCusto { get; private set; }
        public decimal PrecoVenda { get; private set; }

        public Produto(Guid id, string nome, Guid categoriaId, string nomeCategoria, string nomeFornecedor, Guid fornecedorId, int totalEstoque, decimal precoCusto, decimal precoVenda)
        {
            Id = id;
            Nome = nome;
            CategoriaId = categoriaId;
            NomeCategoria = nomeCategoria;
            NomeFornecedor = nomeFornecedor;
            FornecedorId = fornecedorId;
            TotalEstoque = totalEstoque;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
        }
    }
}
