using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Dto.Usuario
{
    public class AtualizarUsuarioDto
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome do usuário é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        public string Sobrenome { get; set; }
    }
}
