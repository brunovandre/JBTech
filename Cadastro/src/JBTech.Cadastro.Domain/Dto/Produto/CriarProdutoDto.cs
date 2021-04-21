using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Dto.Produto
{
    public struct CriarProdutoDto
    {
        public string Nome { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid FornecedorId { get; set; }
        public bool Ativo { get; set; }
    }
}
