using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Dto.Fornecedor
{
    public struct AtualizarFornecedorDto
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome do fornecedor é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        public EnderecoDto Endereco { get; set; }
    }
}
