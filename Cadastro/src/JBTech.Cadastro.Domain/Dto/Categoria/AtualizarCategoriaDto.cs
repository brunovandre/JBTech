using System;
using System.ComponentModel.DataAnnotations;

namespace JBTech.Cadastro.Domain.Dto.Categoria
{
    public struct AtualizarCategoriaDto
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Nome da categoria é obrigatório.")]
        public string Nome { get; set; }
    }
}
