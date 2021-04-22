using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Dto
{
    public struct EnderecoDto
    {
        [Required(ErrorMessage = "Localidade é obrigatorio")]
        public string Localidade { get; set; }
        
        public string Numero { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatorio")]
        public string Bairro { get; set; }
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Cep é obrigatorio")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatorio")]
        public string Cidade { get; set; }
        public string Estado { get; set; }

        [Required(ErrorMessage = "País é obrigatorio")]
        public string Pais { get; set; }
    }
}
