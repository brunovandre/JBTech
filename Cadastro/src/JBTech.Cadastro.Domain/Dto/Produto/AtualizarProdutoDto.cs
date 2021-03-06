using System;
using System.ComponentModel.DataAnnotations;

namespace JBTech.Cadastro.Domain.Dto.Produto
{
    public struct AtualizarProdutoDto
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Id da categoria é obrigatório")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "Id do fornecedor é obrigatório")]
        public Guid FornecedorId { get; set; }

        public int TotalEstoque { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public bool Ativo { get; set; }
    }
}
