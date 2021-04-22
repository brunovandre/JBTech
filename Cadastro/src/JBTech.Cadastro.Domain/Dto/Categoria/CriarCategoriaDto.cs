using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Dto.Categoria
{
    public struct CriarCategoriaDto
    {
        [Required(ErrorMessage = "Nome da categoria é obrigatório.")]
        public string Nome { get; set; }
    }
}
