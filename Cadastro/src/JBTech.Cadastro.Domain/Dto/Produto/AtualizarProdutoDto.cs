using System;

namespace JBTech.Cadastro.Domain.Dto.Produto
{
    public struct AtualizarProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid FornecedorId { get; set; }
        public bool Ativo { get; set; }
    }
}
