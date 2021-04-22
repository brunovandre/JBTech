
using System.ComponentModel.DataAnnotations;

namespace JBTech.Cadastro.Domain.Dto.Usuario
{
    public struct CriarUsuarioDto
    {
        [Required(ErrorMessage = "Nome do usuário é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [MaxLength(13, ErrorMessage = "A senha deve ter no mínimo 13 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Cpf é obrigatório")]
        public string Cpf { get; set; }

        public bool Ativo { get; set; }
    }
}
