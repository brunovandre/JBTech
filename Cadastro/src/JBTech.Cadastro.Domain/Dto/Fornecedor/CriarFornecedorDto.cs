
using System.ComponentModel.DataAnnotations;

namespace JBTech.Cadastro.Domain.Dto.Fornecedor
{
    public struct CriarFornecedorDto
    {
        [Required(ErrorMessage = "Nome do fornecedor é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Cnpj é obrigatório.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        public EnderecoDto Endereco { get; set; }
    }
}
