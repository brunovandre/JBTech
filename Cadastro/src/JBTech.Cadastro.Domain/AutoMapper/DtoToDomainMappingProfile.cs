using AutoMapper;
using JBTech.Cadastro.Domain.Dto;
using JBTech.Cadastro.Domain.Dto.Categoria;
using JBTech.Cadastro.Domain.Dto.Fornecedor;
using JBTech.Cadastro.Domain.Dto.Produto;
using JBTech.Cadastro.Domain.Dto.Usuario;
using JBTech.Cadastro.Domain.Entities;
using JBTech.Cadastro.Domain.ValueObjects;

namespace JBTech.Cadastro.API.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {

            MapearCategoria();
            MapearFornecedor();
            MapearProduto();
            MapearUsuario();

           
        }

        public void MapearCategoria()
        {
            CreateMap<CriarCategoriaDto, Categoria>()
                .ConstructUsing(p =>
                    new Categoria(p.Nome, null));
        }

        public void MapearFornecedor()
        {
            CreateMap<CriarFornecedorDto, Fornecedor>()
              .ConstructUsing(p =>
                  new Fornecedor(p.Nome, p.CNPJ, p.Email, p.Telefone, new Endereco(p.Endereco.Localidade, p.Endereco.Numero, p.Endereco.Bairro, p.Endereco.Complemento, p.Endereco.Cep, p.Endereco.Cidade, p.Endereco.Estado, p.Endereco.Pais), null));
        }

        public void MapearProduto()
        {
            CreateMap<CriarProdutoDto, Produto>()
                .ConstructUsing(p =>
                    new Produto(p.Nome, p.CategoriaId, null, null, p.FornecedorId, p.Ativo, null));
        }

        public void MapearUsuario()
        {
            CreateMap<CriarUsuarioDto, Usuario>()
              .ConstructUsing(p =>
                  new Usuario(p.Nome, p.Sobrenome, p.Email, p.Senha, p.Cpf, null));
        }

        public void MapearEndereco()
        {
            CreateMap<EnderecoDto, Endereco>()
              .ConstructUsing(p =>
                  new Endereco(p.Localidade, p.Numero, p.Bairro, p.Complemento, p.Cep, p.Cidade, p.Estado, p.Pais));
        }
    }
}
