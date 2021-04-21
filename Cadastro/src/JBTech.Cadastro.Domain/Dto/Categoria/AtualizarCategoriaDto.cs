using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Dto.Categoria
{
    public struct AtualizarCategoriaDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
